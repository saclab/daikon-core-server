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
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Tasks;
using Microsoft.Extensions.Logging;

namespace Application.BackgroundTasks.GeneSync
{
  public class GeneSync : IGeneSync
  {
    private readonly ILogger<GeneSync> _logger;
    private static readonly HttpClient _client = new HttpClient();


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

    public GeneSync(ILogger<GeneSync> logger)
    {
      _logger = logger;
    }

    public async Task Sync(BTask task, CancellationToken cancellationToken = default)
    {
      _logger.LogInformation("Doing heavy Gene Syncing logic ...");

      await Task.Delay(2500, cancellationToken);

      // 1. Fetch CSV From Mycobrowser

      var CSVRecordsFromMycobrowser = await fetchCSVFromMycobrowser();

      // 2. Read each line

      foreach (var CSVGene in CSVRecordsFromMycobrowser)
      {
        // 3. compare Rv Number, if Gene exists update, else create new
        // fetch gene from db

        
          
      }

      

      // 4. Update the job to complete 

      _logger.LogInformation("\"{id} by {type}\" has been completed!", task.Id, task.Type);
    }

    public async Task<IEnumerable<GeneCSV>> fetchCSVFromMycobrowser()
    {
      
      _client.DefaultRequestHeaders.Accept.Clear();
      Console.WriteLine(">>>>> Getting fetchJSONTextFromMycobrowser()");
      var stringTask = await _client.GetStreamAsync("https://mycobrowser.epfl.ch/releases/4/get_file?dir=txt&file=Mycobacterium_tuberculosis_H37Rv.txt");
      Console.WriteLine("<<>><<<<< Converting fetchJSONTextFromMycobrowser()");
      StreamReader streamReader = new StreamReader(stringTask);

      var csv = new CsvReader(streamReader, MycobrowserCSVConfig);
      var records = csv.GetRecords<GeneCSV>();

      return records;
    }
  }
}