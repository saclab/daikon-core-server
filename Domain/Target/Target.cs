using System;

namespace Domain
{
  public class Target
  {
    public Guid Id { get; set; }
    public string AccessionNumber { get; set; }
    public string GeneName { get; set; }
    public Gene BaseGene { get; set; }
    public double Score { get; set; }
    public double HTSFeasibility { get; set; }
    public double SBDFeasibility { get; set; }
    public double Progressibility { get; set; }
    public double Saftey { get; set; }

  }
}