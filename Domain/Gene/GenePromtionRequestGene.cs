using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class GenePromtionRequestGene : Metadata
  {
    public Guid Id { get; set; }
    public Guid GenePromotionRequestId { get; set; }
    public Guid GeneId { get; set; }

  }
}