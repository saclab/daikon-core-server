using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Votes.DTOs
{
  public class RegisterVoteDTO
  {
    public Guid VoteId { get; set; }
    public string VoteButton { get; set; }
    public string Comment { get; set; }

  }
}