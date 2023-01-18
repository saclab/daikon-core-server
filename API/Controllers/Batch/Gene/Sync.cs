using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xyaneon.Bioinformatics.FASTA;
using Xyaneon.Bioinformatics.FASTA.IO;

namespace API.Controllers.Batch.Gene
{
  [ApiController]
  [Route("api/batch/gene/[controller]")]

  public class Sync
  {
    private readonly IBackgroundQueue<BTask> _queue;

    public Sync(IBackgroundQueue<BTask> queue)
    {
      _queue = queue;
    }

    [HttpGet]
    public async Task<ActionResult<BTask>> createTask()
    {
      Guid gid = Guid.NewGuid();
      var btask = new BTask
      {
        Id = gid,
        Status = "New",
        Type = "GeneSync"

      };
      _queue.Enqueue(btask);

      return btask;

    }

    [HttpGet("{id}")]
    public async Task<Sequence> EditActivity()
    {
      Sequence sequence = SequenceFileReader.ReadSingleFromFile("/app/DevFiles/test.fasta");


      Console.WriteLine(">>>>> Header : " + sequence.Header.Items[4]);


      return sequence;
    }

  }
}