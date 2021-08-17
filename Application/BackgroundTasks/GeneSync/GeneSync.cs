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

    public GeneSync(DataContext context, IMapper mapper, ILogger<GeneSync> logger, IMediator mediator)
    {
      _logger = logger;
      _context = context;
      _mapper = mapper;
      _mediator = mediator;
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

        var findGene = await _context.Genes
          .FirstOrDefaultAsync(g => g.AccessionNumber == CSVGene.AccessionNumber);

        if (findGene == null) {
          var newGene = new Gene();
          var newGenePublicData = new GenePublicData();
          
          _mapper.Map(CSVGene, newGene);
          _mapper.Map(CSVGene, newGenePublicData);
          newGene.GenePublicData = newGenePublicData;

          _logger.LogInformation("Adding ..." + newGene.AccessionNumber);
          await _mediator.Send(new Create.Command { Gene = newGene });
        }

          
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