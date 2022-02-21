using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Votes.DTOs;
using Domain;

namespace Application.Screens.DTOs
{
  public class HitDTO
  {
    public Guid Id { get; set; }
    public Guid ScreenId { get; set; }
    public string TargetName { get; set; }
    public string Library { get; set; }
    public string Source { get; set; }
    public string Method { get; set; }
    public string MIC { get; set; }
    public string IC50 { get; set; }
    public int ClusterGroup { get; set; }
    public Guid CompoundId { get; set; }
    public Compound Compound { get; set; }

    public Guid VoteId { get; set; }
    public VoteDTO Vote { get; set; }
  }
}