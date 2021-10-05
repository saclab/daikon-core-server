using System;

namespace Domain
{
  public class Target
  {
    public Guid Id { get; set; }
    public Gene BaseGene { get; set; }
    public Guid GeneId { get; set; }
    public string AccessionNumber { get; set; }
    public string GeneName { get; set; }
    public string Bucket { get; set; }
    public double ImpactScore { get; set; }
    public double LikeScore { get; set; }
    public double HTSFeasibility { get; set; }
    public double SBDFeasibility { get; set; }
    public double Progressibility { get; set; }
    public double Safety { get; set; }
    public TargetScorecard TargetScorecard { get; set; }

  }
}