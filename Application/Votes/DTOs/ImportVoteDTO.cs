using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Persistence;

namespace Application.Votes.DTOs
{
  public class ImportVoteDTO
  {
    public Guid Id { get; set; }
    public int Positive { get; set; }
    public int Neutral { get; set; }
    public int Negative { get; set; }

  }
}