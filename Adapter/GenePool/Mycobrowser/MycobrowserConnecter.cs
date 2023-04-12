using System.Globalization;
using System.Text;
using Adapter.GenePool.Mycobrowser.Configuration;
using Adapter.GenePool.Mycobrowser.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using Microsoft.Extensions.Logging;
using Xyaneon.Bioinformatics.FASTA.IO;

namespace Adapter.GenePool.Mycobrowser
{
  public class MycobrowserConnecter : IGenePoolAdapter
  {
    private static string _ADAPTER_NAME = "MycobrowserConnecter";
    private static string _ADAPTER_TYPE = "GenePoolSync";
    private static string _ADAPTER_VERSION = "1.0.0";
    private readonly ILogger<MycobrowserConnecter> _logger;
    private static readonly HttpClient _client = new HttpClient();

    private MycobrowswerAdapterGeneSyncConfiguration Conf { get; set; }


    private CsvConfiguration _mycobrowserCSVConfig;



    public MycobrowserConnecter()
    {
      _logger = new LoggerFactory().CreateLogger<MycobrowserConnecter>();


      _mycobrowserCSVConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        Delimiter = Microsoft.VisualBasic.Constants.vbTab,
        HasHeaderRecord = true,
        // TrimOptions = TrimOptions.Trim,
        // Mode = CsvMode.RFC4180,
        MissingFieldFound = null,
        HeaderValidated = null,
        Encoding = Encoding.UTF8,

      };
    }


    public string GetAdapterName()
    {
      return _ADAPTER_NAME;
    }

    public string GetAdapterVersion()
    {
      return _ADAPTER_VERSION;
    }

    public string GetAdapterType()
    {
      return _ADAPTER_TYPE;
    }

    public void Init(IGeneSyncAdapterConfiguration configuration)
    {
      if (configuration == null)
      {
        throw new ArgumentNullException(nameof(configuration));
      }

      if (configuration.GetType() != typeof(MycobrowswerAdapterGeneSyncConfiguration))
      {
        throw new ArgumentException("Configuration is not of type MycobrowswerAdapterGeneSyncConfiguration");
      }

      Conf = (MycobrowswerAdapterGeneSyncConfiguration)configuration;
    }

    public async Task<List<Gene>> FetchGenes()
    {

      // Fetch the configuration for the gene pool

      List<Gene> FormattedGenes = new List<Gene>();

      var CSVRecordsFromMycobrowser = await fetchCSVFromMycobrowser(Conf.GeneFileURL);
      _logger.LogDebug("CSVRecordsFromMycobrowser.Count : " + CSVRecordsFromMycobrowser.Count());
      var geneSequencesFromMycobrowser = await fetchGeneSequencesFromMycobrowser(Conf.GeneFASTAFileURL);
      var proteinSequenceFromMycobrowser = await fetchProteinSequencesFromMycobrowser(Conf.ProteinFASTAFileURL);

      foreach (MycobrowserGeneCSVModel geneCSVRecord in CSVRecordsFromMycobrowser)
      {
        _logger.LogDebug("Dealing with : " + geneCSVRecord.AccessionNumber);
        Gene FormattedGene = new Gene();
        FormattedGene.AccessionNumber = geneCSVRecord.AccessionNumber;
        FormattedGene.GeneName = geneCSVRecord.GeneName;
        FormattedGene.Function = geneCSVRecord.Function;
        FormattedGene.Product = geneCSVRecord.Product;
        FormattedGene.FunctionalCategory = geneCSVRecord.FunctionalCategory;
        FormattedGene.GenePublicData = new GenePublicData();

        // Gene Sequence Data
        var geneSequenceData =
                (from geneSequence in geneSequencesFromMycobrowser
                 where geneSequence.GeneName == FormattedGene.AccessionNumber
                 select new
                 {
                   GeneLength = geneSequence.GeneLength,
                   GeneName = geneSequence.GeneName,
                   geneSequence = geneSequence.GeneSequenceData
                 }).FirstOrDefault();

        if (geneSequenceData != null)
        {
          string[] geneLengthString = geneSequenceData.GeneLength.Split('-');
          FormattedGene.GenePublicData.Location = geneLengthString[0];
          FormattedGene.GenePublicData.GeneLength = (Int32.Parse(geneLengthString[1]) - Int32.Parse(geneLengthString[0]) + 1).ToString();
          FormattedGene.GenePublicData.GeneSequence = geneSequenceData.geneSequence;
        }

        // Protein Sequence Data
        var proteinSequenceData =
                 (from proteinSequence in proteinSequenceFromMycobrowser
                  where proteinSequence.ProteinName == FormattedGene.AccessionNumber
                  select new
                  {
                    Product = proteinSequence.Product,
                    ProteinLength = proteinSequence.ProteinLength,
                    ProteinSequence = proteinSequence.ProteinSequenceData
                  }).FirstOrDefault();

        if (proteinSequenceData != null)
        {
          FormattedGene.GenePublicData.ProteinLength = proteinSequenceData.ProteinLength;
          FormattedGene.GenePublicData.ProteinSequence = proteinSequenceData.ProteinSequence;
        }

        var uniProtGeneExternalID = new GeneExternalId
        {
          GeneAccessionNumber = geneCSVRecord.AccessionNumber,
          ExternalIdRef = "UniProt",
          ExternalId = geneCSVRecord.UniProt
        };

        FormattedGene.GeneExternalIds = new List<GeneExternalId>();
        FormattedGene.GeneExternalIds.Add(uniProtGeneExternalID);

        FormattedGenes.Add(FormattedGene);
      }

      return FormattedGenes;

    }

    // Fetch core gene data from mycobrowser
    private async Task<IEnumerable<MycobrowserGeneCSVModel>> fetchCSVFromMycobrowser(string mycobrowserFileURL)
    {
      if (mycobrowserFileURL == null)
      {
        throw new ArgumentNullException(nameof(mycobrowserFileURL));
      }
      _client.DefaultRequestHeaders.Accept.Clear();
      _logger.LogDebug("[STARTED] fetchCSVFromMycobrowser()");
      _logger.LogDebug("Fetching data from mycobrowser: " + mycobrowserFileURL);

      string parsedAPIData = "";

      // Fetch the raw data from the mycobrowser API
      try
      {
        parsedAPIData = await _client.GetStringAsync(mycobrowserFileURL);
      }
      catch (Exception e)
      {
        _logger.LogCritical(e.Message);
      }

      if (parsedAPIData == null)
      {
        // failed to fetch data from mycobrowser
        _logger.LogCritical("Failed to fetch data from mycobrowser" + mycobrowserFileURL);
        throw new Exception("Failed to fetch data from mycobrowser");
      }

      // Parse the raw data into a list of MycobrowserGeneCSVModel
      using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(parsedAPIData)))
      using (var streamReader = new StreamReader(stream))
      {
        var csv = new CsvReader(streamReader, _mycobrowserCSVConfig);
        var records = csv.GetRecords<MycobrowserGeneCSVModel>();

        _logger.LogDebug("[FINISHED] fetchCSVFromMycobrowser()");
        return records.ToList();
      }
    }



    private async Task<List<MycobrowserGeneSequenceModel>> fetchGeneSequencesFromMycobrowser(string mycobrowserFileURL)
    {
      if (mycobrowserFileURL == null)
      {
        throw new ArgumentNullException(nameof(mycobrowserFileURL));
      }
      if (Conf.TempFilesDir == null)
      {
        throw new ArgumentNullException(nameof(Conf.TempFilesDir));
      }
      _client.DefaultRequestHeaders.Accept.Clear();
      _logger.LogDebug("[STARTED] fetchGeneSequencesFromMycobrowser()");
      _logger.LogDebug("Fetching data from mycobrowser: " + mycobrowserFileURL);

      string parsedAPIData = "";

      // Fetch the raw data from the mycobrowser API
      try
      {
        parsedAPIData = await _client.GetStringAsync(mycobrowserFileURL);
      }
      catch (Exception e)
      {
        _logger.LogCritical(e.Message);
      }

      if (parsedAPIData == null)
      {
        // failed to fetch data from mycobrowser
        _logger.LogCritical("Failed to fetch data from mycobrowser" + mycobrowserFileURL);
        throw new Exception("Failed to fetch data from mycobrowser");
      }

      // write parsedAPIData to a temporary file
      string tempFileBasePath = Conf.TempFilesDir + "/" + this.GetAdapterType() + "/" + this.GetAdapterName() + "/" + this.GetAdapterVersion() + "/";
      string tempFileName = Conf.StrainName ?? "UNKNOWN_GENE_SEQ.fasta" + "_GENE.fasta";
      string tempFilePath = Path.Combine(tempFileBasePath, tempFileName);


      if (!Directory.Exists(tempFileBasePath))
      {
        // If the directory doesn't exist, create it
        Directory.CreateDirectory(tempFileBasePath);
      }


      using (var stream = new FileStream(tempFilePath, FileMode.Create))
      {
        using (var writer = new StreamWriter(stream))
        {
          writer.Write(parsedAPIData);
        }
      }

      List<MycobrowserGeneSequenceModel> geneSequenceList = new List<MycobrowserGeneSequenceModel>();

      var geneSequences = SequenceFileReader.ReadMultipleFromFile(tempFilePath);
      foreach (var geneSeq in geneSequences)
      {
        try
        {
          geneSequenceList.Add(new MycobrowserGeneSequenceModel()
          {
            GeneLength = geneSeq.Header.Items[3].ToString(),
            GeneName = geneSeq.Header.Items[0].ToString(),
            GeneSequenceData = geneSeq.Data.Characters
          });
        }
        catch (Exception e)
        {
          _logger.LogCritical(e.Message);
        }
      }
      return geneSequenceList;
    }



    private async Task<List<MycobrowserProteinSequenceModel>> fetchProteinSequencesFromMycobrowser(string mycobrowserFileURL)
    {
      if (mycobrowserFileURL == null)
      {
        throw new ArgumentNullException(nameof(mycobrowserFileURL));
      }
      if (Conf.TempFilesDir == null)
      {
        throw new ArgumentNullException(nameof(Conf.TempFilesDir));
      }

      _client.DefaultRequestHeaders.Accept.Clear();
      _logger.LogDebug("[STARTED] fetchProteinSequencesFromMycobrowser()");
      _logger.LogDebug("Fetching data from mycobrowser: " + mycobrowserFileURL);

      string parsedAPIData = "";
      string[] parsedAPIDataCleaned;

      try
      {
        parsedAPIData = await _client.GetStringAsync(mycobrowserFileURL);
      }
      catch (Exception e)
      {
        _logger.LogCritical(e.Message);
      }

      if (parsedAPIData.Length == 0)
      {
        _logger.LogCritical("Failed to fetch data from mycobrowser" + mycobrowserFileURL);
        throw new Exception("Failed to fetch data from mycobrowser");
      }


      // Clean the data as some have line breaks.
      parsedAPIDataCleaned = parsedAPIData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

      string tempFileBasePath = Conf.TempFilesDir + "/" + this.GetAdapterType() + "/" + this.GetAdapterName() + "/" + this.GetAdapterVersion() + "/";
      string tempFileName = Conf.StrainName ?? "UNKNOWN_PROT_SEQ.fasta" + "_PROT.fasta";
      string tempFilePath = Path.Combine(tempFileBasePath, tempFileName);


      if (!Directory.Exists(tempFileBasePath))
      {
        // If the directory doesn't exist, create it
        Directory.CreateDirectory(tempFileBasePath);
      }



      using (StreamWriter outputFile = new StreamWriter(tempFilePath))
      {
        foreach (string line in parsedAPIDataCleaned)
        {
          if (line.Length != 0)
          {
            await outputFile.WriteLineAsync(line);
          }
        }
      }

      List<MycobrowserProteinSequenceModel> protSequenceList = new List<MycobrowserProteinSequenceModel>();

      try
      {
        var proteinSequences = SequenceFileReader.ReadMultipleFromFile(tempFilePath);
        foreach (var protSeq in proteinSequences)
        {
          try
          {
            protSequenceList.Add(new MycobrowserProteinSequenceModel()
            {
              ProteinName = protSeq.Header.Items[0].ToString(),
              Product = protSeq.Header.Items[2].ToString(),
              ProteinLength = protSeq.Header.Items[3].ToString(),
              ProteinSequenceData = protSeq.Data.Characters
            });
          }
          catch (Exception e)
          {
            _logger.LogCritical(e.Message);
          }
        }
      }
      catch (Exception e)
      {
        _logger.LogCritical(e.Message);
      }
      return protSequenceList;
    }
  }
}