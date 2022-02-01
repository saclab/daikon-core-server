using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
  public class Target
  {
    public Guid Id { get; set; }
    public Guid StrainId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<TargetGene> TargetGenes { get; set; }
    public string Bucket { get; set; }
    public double ImpactScore { get; set; }
    public double ImpactComplete { get; set; }
    public double LikeScore { get; set; }
    public double LikeComplete { get; set; }
    public double ScreeningScore { get; set; }
    public double ScreeningComplete { get; set; }
    public double StructureScore { get; set; }
    public double StructureComplete { get; set; }
    public double VulnerabilityRatio { get; set; }
    public double VulnerabilityRank { get; set; }
    public double HTSFeasibility { get; set; }
    public double SBDFeasibility { get; set; }
    public double Progressibility { get; set; }
    public double Safety { get; set; }
    public TargetScorecard TargetScorecard { get; set; }

  }
}