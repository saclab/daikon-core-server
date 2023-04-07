using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.GenePool.Mycobrowser.DTO;
using Application.Interfaces;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;
using Xyaneon.Bioinformatics.FASTA.IO;

namespace Adapter.GenePool.Mycobrowser
{
  public class MycobrowserConnecter : IAdapterGenePool
  {
    private static string _ADAPTER_NAME = "Mycobrowser";
    private static string _ADAPTER_VERSION = "1.0.0";
    private readonly ILogger<MycobrowserConnecter> _logger;
    private static readonly HttpClient _client = new HttpClient();
    private readonly IMapper _mapper;
    private IMediator _mediator;

    private CsvConfiguration _mycobrowserCSVConfig;


    public MycobrowserConnecter(IMapper mapper, ILogger<MycobrowserConnecter> logger, IMediator mediator)
    {
      _logger = logger;
      _mapper = mapper;
      _mediator = mediator;

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

    public Task<List<Gene>> SyncPool(string genePoolConfigurationName)
    {

      // Fetch the configuration for the gene pool
      
      throw new NotImplementedException();
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
      string tempFilePath = "/app/TempFiles/Mycobacterium_tuberculosis_H37Rv.fasta";
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
      var tempFile = "/app/TempFiles/Mycobacterium_tuberculosis_H37Rv_protein.fasta";
      using (StreamWriter outputFile = new StreamWriter(tempFile))
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
        var proteinSequences = SequenceFileReader.ReadMultipleFromFile(tempFile);
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