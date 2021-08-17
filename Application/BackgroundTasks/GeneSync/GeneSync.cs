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
using Xyaneon.Bioinformatics.FASTA;
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

      // var CSVRecordsFromMycobrowser = await fetchCSVFromMycobrowser();
      var GeneSequences = await fetchIndividualGeneSequencesFromMycobrowser();

      // 2. Read each line

      // foreach (var CSVGene in CSVRecordsFromMycobrowser)
      // {
      //   // 3. compare Rv Number, if Gene exists update, else create new
      //   // fetch gene from db

      //   var findGene = await _context.Genes
      //     .FirstOrDefaultAsync(g => g.AccessionNumber == CSVGene.AccessionNumber);

      //   if (findGene == null) {
      //     var newGene = new Gene();
      //     var newGenePublicData = new GenePublicData();

      //     _mapper.Map(CSVGene, newGene);
      //     _mapper.Map(CSVGene, newGenePublicData);
      //     newGene.GenePublicData = newGenePublicData;

      //     var geneD = from geneSequence in GeneSequences
      //     where geneSequence.Header.Items[1].ToString() == CSVGene.AccessionNumber
      //     select new {GeneLength = geneSequence.Header.Items[3]};

      //     _logger.LogInformation("Adding ..." + newGene.AccessionNumber);
      //     await _mediator.Send(new Create.Command { Gene = newGene });
      //   }


      // }










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


    public async Task<IEnumerable<Sequence>> fetchIndividualGeneSequencesFromMycobrowser()
    {
      // _client.DefaultRequestHeaders.Accept.Clear();
      // Console.WriteLine(">>>>> Getting fetchIndividualGeneSequencesFromMycobrowser()");
      // var stringTask = await _client.GetStringAsync("https://mycobrowser.epfl.ch/releases/4/get_file?dir=fasta_genes&file=Mycobacterium_tuberculosis_H37Rv.fasta");

      // using (StreamWriter outputFile = new StreamWriter("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv.fasta"))
      // {

      //   outputFile.WriteLine(stringTask);
      // }


      // Console.WriteLine("<<>><<<<< Converting fetchIndividualGeneSequencesFromMycobrowser()");
      IEnumerable<Sequence> sequences = SequenceFileReader.ReadMultipleFromFile("/app/TempFiles/Mycobacterium_tuberculosis_H37Rv.fasta");



      var geneD = (from geneSequence in sequences
                   where geneSequence.Header.Items[1].ToString() == "Rv3729"
                   select new { 
                     GeneLength = geneSequence.Header.Items[3],
                     GeneName = geneSequence.Header.Items[1],
                     geneSequence = geneSequence.Data.Characters}).FirstOrDefault();

      string[] geneLengthString = geneD.GeneLength.ToString().Split('-');
      var geneStartLocation = Int32.Parse(geneLengthString[0]);
      var geneEndLocation = Int32.Parse(geneLengthString[1]);
      var geneLength = geneEndLocation - geneStartLocation + 1;

      Console.WriteLine("<<>><<<<< Gene Name = " + geneD.GeneName);
      Console.WriteLine("<<>><<<<< Gene Start = " + geneStartLocation);
      Console.WriteLine("<<>><<<<< Gene End = " + geneEndLocation);
      Console.WriteLine("<<>><<<<< Gene Length = " + geneLength);
      Console.WriteLine("<<>><<<<< Gene Sequence = " + geneD.geneSequence);


      return sequences;
    }
  }
}