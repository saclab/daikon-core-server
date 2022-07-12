using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.BackgroundTasks.GeneSync.DTO;
using Application.Genes;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using Domain.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using Xyaneon.Bioinformatics.FASTA.IO;

namespace Application.BackgroundTasks.GeneSync
{
  public class GeneSync : IGeneSync
  {
    private readonly ILogger<GeneSync> _logger;
    private static readonly HttpClient _client = new HttpClient();
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    private IMediator _mediator;


    CsvConfiguration MycobrowserCSVConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
      Delimiter = Microsoft.VisualBasic.Constants.vbTab,
      HasHeaderRecord = true,
      // TrimOptions = TrimOptions.Trim,
      // Mode = CsvMode.RFC4180,
      MissingFieldFound = null,
      HeaderValidated = null,
      Encoding = Encoding.UTF8,

    };
    CsvConfiguration DefaultCSVConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
      HasHeaderRecord = true,
      // TrimOptions = TrimOptions.Trim,
      // Mode = CsvMode.RFC4180,
      MissingFieldFound = null,
      HeaderValidated = null,
      Encoding = Encoding.UTF8,

    };

    public GeneSync(DataContext context, IMapper mapper, ILogger<GeneSync> logger, IMediator mediator)
    {
      _logger = logger;
      _context = context;
      _mapper = mapper;
      _mediator = mediator;
    }

    public async Task Sync(BTask task, CancellationToken cancellationToken = default)
    {
      _logger.LogInformation("Starting pulling data from mycobrowser.");

      /* 1. Fetch CSV From Mycobrowser */

      var CSVRecordsFromMycobrowser = await fetchCSVFromMycobrowser();
      var GeneSequences = await fetchIndividualGeneSequencesFromMycobrowser();
      var ProteinSequences = await fetchIndividualProteinSequencesFromMycobrowser();
      var CSVVulnerabilities = fetchCSVVulnerability();
      _logger.LogInformation("Genes pulled " + GeneSequences.Count());

      /* Read each line */

      foreach (var CSVGene in CSVRecordsFromMycobrowser)
      {
        /* compare Rv Number, if Gene exists update, else create new */
        _logger.LogDebug("Dealing with : " + CSVGene.AccessionNumber);

        var findGene = await _context.Genes
          .FirstOrDefaultAsync(g => g.AccessionNumber == CSVGene.AccessionNumber);

        if (findGene == null)
        {
          _logger.LogDebug("Not Found. Creating new Gene: " + CSVGene.AccessionNumber);
          var newGene = new Gene();
          var newGenePublicData = new GenePublicData();

          /*
          First get data from the TSV
          */
          _mapper.Map(CSVGene, newGene);
          _mapper.Map(CSVGene, newGenePublicData);

          /*
          Second get genome sequence data from the TSV
          */

          try
          {

            var geneSequenceData = (from geneSequence in GeneSequences
                                    where geneSequence.GeneName == CSVGene.AccessionNumber
                                    select new
                                    {
                                      GeneLength = geneSequence.GeneLength,
                                      GeneName = geneSequence.GeneName,
                                      geneSequence = geneSequence.GeneSequenceData
                                    }).FirstOrDefault();

            string[] geneLengthString = geneSequenceData.GeneLength.Split('-');
            newGenePublicData.Location = geneLengthString[0];
            newGenePublicData.GeneLength = (Int32.Parse(geneLengthString[1]) - Int32.Parse(geneLengthString[0]) + 1).ToString();
            newGenePublicData.GeneSequence = geneSequenceData.geneSequence;
          }

          catch (Exception e)
          {
            _logger.LogCritical(e.Message);
          }

          /*
          Third get protein data from TSV file
          */
          try
          {
            var proteinSequenceData = (from proteinSequence in ProteinSequences
                                       where proteinSequence.ProteinName == CSVGene.AccessionNumber
                                       select new
                                       {
                                         Product = proteinSequence.Product,
                                         ProteinLength = proteinSequence.ProteinLength,
                                         ProteinSequence = proteinSequence.ProteinSequenceData
                                       }).FirstOrDefault();

            newGenePublicData.ProteinLength = proteinSequenceData.ProteinLength;
            newGenePublicData.ProteinSequence = proteinSequenceData.ProteinSequence;
          }
          catch (Exception e)
          {
            _logger.LogCritical(e.Message);
          }

          /*
          Add Gene
          */
          newGene.GenePublicData = newGenePublicData;
          _logger.LogInformation("Adding new Gene" + newGene);
          await _mediator.Send(new Create.Command { Gene = newGene });
        }

        else
        {
          /* TODO: Update existing genes */

          /* Right now we are only updating Gene Extternal IDs */


          /* STEP 1 : Update UNIPROT IDs */

          //var gene = await _context.Genes
          //.Include(g => g.GeneExternalIds)
          //.FirstOrDefaultAsync(g => g.AccessionNumber == CSVGene.AccessionNumber);

          //var uniprotGeneExternalID = new GeneExternalId
          //{
          //  Id = Guid.NewGuid(),
          //  GeneId = gene.Id,
          //  GeneAccessionNumber = gene.AccessionNumber,
          //  ExternalIdRef = "UniProt",
          //  ExternalId = CSVGene.UniProt
          //};

          //if (gene.GeneExternalIds == null)
          //{
          //  gene.GeneExternalIds = new List<GeneExternalId>();
          //  gene.GeneExternalIds.Add(uniprotGeneExternalID);
          //  _context.GeneExternalIds.Add(newGenePublicData);
          //}
          //else
          //{
          //  var uniprotRef = gene.GeneExternalIds.FirstOrDefault(i => i.ExternalIdRef == "UniProt");
          //  if (uniprotRef == null)
          //  {
          //    gene.GeneExternalIds.Add(uniprotGeneExternalID);
          //    _context.GeneExternalIds.Add(newGenePublicData);
          //  }
          //  else
          //  {
          //    uniprotRef.ExternalId = CSVGene.UniProt;
          //  }

          //}


        }




      }

      _logger.LogInformation("Gene Vulnerability Data");

      // Vulnerability Data
      foreach (var CSVVulnerability in CSVVulnerabilities)
      {
        Gene findGene = await _context.Genes
          .Include(g => g.GenePublicData)
          // .Include(g => g.GeneNonPublicData)
          .Include(g => g.GeneEssentiality)
          .Include(g => g.GeneVulnerability)
          .FirstOrDefaultAsync(g => g.AccessionNumber == CSVVulnerability.GeneAccessionNumber);

        if (findGene != null && findGene.GeneVulnerability.Count == 0)
        {
          var newGeneVulnerability = new GeneVulnerability();
          _mapper.Map(CSVVulnerability, newGeneVulnerability);
          newGeneVulnerability.GeneId = findGene.Id;
          newGeneVulnerability.GeneAccessionNumber = findGene.AccessionNumber;
          newGeneVulnerability.CreatedAt = DateTime.UtcNow;
          newGeneVulnerability.CreatedBy = "System Sync";
          newGeneVulnerability.GeneId = findGene.Id;
          findGene.GeneVulnerability = new List<GeneVulnerability>();
          findGene.GeneVulnerability.Add(newGeneVulnerability);

          _context.GeneVulnerability.Add(newGeneVulnerability);
          await _context.SaveChangesAsync();
          _logger.LogInformation("Added Vulnerability for Gene" + CSVVulnerability.GeneAccessionNumber);
        }

      }


      // 4. Update the job to complete 


      _logger.LogInformation("\"{id} by {type}\" has been completed!", task.Id, task.Type);
    }

    public async Task<IEnumerable<GeneCSV>> fetchCSVFromMycobrowser()
    {

      _client.DefaultRequestHeaders.Accept.Clear();
      _logger.LogDebug("fetchCSVFromMycobrowser()");

      string stringTask = null;

      try
      {
        stringTask = await _client.GetStringAsync(
       "https://mycobrowser.epfl.ch/releases/4/get_file?dir=txt&file=Mycobacterium_tuberculosis_H37Rv.txt");

      }
      catch (Exception e)
      {
        _logger.LogCritical(e.Message);
      }

      using (StreamWriter outputFile3 = new StreamWriter("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv.txt"))
      {
        outputFile3.WriteLine(stringTask);
      }

      StreamReader streamReader = new StreamReader("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv.txt");

      var csv = new CsvReader(streamReader, MycobrowserCSVConfig);
      var records = csv.GetRecords<GeneCSV>();

      return records;
    }

    public IEnumerable<GeneVulnerabilityCSV> fetchCSVVulnerability()
    {

      StreamReader streamReader = new StreamReader("/app/TempFiles/GeneVulnerability.csv");

      var csv = new CsvReader(streamReader, DefaultCSVConfig);
      var records = csv.GetRecords<GeneVulnerabilityCSV>();

      return records;
    }


    public async Task<List<GeneSequence>> fetchIndividualGeneSequencesFromMycobrowser()
    {
      _client.DefaultRequestHeaders.Accept.Clear();
      _logger.LogDebug("fetchIndividualGeneSequencesFromMycobrowser()");


      string stringTask = null;
      try
      {
        stringTask = await _client.GetStringAsync(
      "https://mycobrowser.epfl.ch/releases/4/get_file?dir=fasta_genes&file=Mycobacterium_tuberculosis_H37Rv.fasta");
      }
      catch (Exception e)
      {
        _logger.LogCritical(e.Message);
      }


      using (StreamWriter outputFile1 = new StreamWriter("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv.fasta"))
      {

        outputFile1.WriteLine(stringTask);
      }


      List<GeneSequence> geneSequenceList = new List<GeneSequence>();

      var geneSequences = SequenceFileReader.ReadMultipleFromFile("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv.fasta");
      foreach (var geneSeq in geneSequences)
      {
        try
        {
          geneSequenceList.Add(new GeneSequence()
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

    public async Task<List<ProteinSequence>> fetchIndividualProteinSequencesFromMycobrowser()
    {
      _client.DefaultRequestHeaders.Accept.Clear();
      _logger.LogDebug("fetchIndividualProteinSequencesFromMycobrowser()");

      string stringTask = null;
      string[] lines = null;

      try
      {
        stringTask = await _client.GetStringAsync("https://mycobrowser.epfl.ch/releases/4/get_file?dir=fasta_proteins&file=Mycobacterium_tuberculosis_H37Rv.fasta");
        lines = stringTask.Split(
                new[] { "\r\n", "\r", "\n" },
                  StringSplitOptions.None
                );
      }
      catch (Exception e)
      {
        _logger.LogCritical(e.Message);
      }


      using (StreamWriter outputFile2 = new StreamWriter("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv_protein.fasta"))
      {

        foreach (string line in lines)
        {
          if (line.Length != 0)
          {
            await outputFile2.WriteLineAsync(line);
          }
          else
          {
            await outputFile2.WriteLineAsync("NOTAVAIL");
          }
        }
      }

      List<ProteinSequence> protSequenceList = new List<ProteinSequence>();

      try
      {
        var proteinSequences = SequenceFileReader.ReadMultipleFromFile("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv_protein.fasta");


        foreach (var protSeq in proteinSequences)
        {
          try
          {
            protSequenceList.Add(new ProteinSequence()
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