using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain
{
  public class GeneCRISPRiStrain : Metadata
  {
    /*
      Define: CRISPR stands for Clustered Regularly Interspaced Short Palindromic Repeats
      is a genetic engineering technique in molecular biology by which the genomes of 
      living organisms may be modified. It is based on a simplified version of the bacterial 
      CRISPR-Cas9 antiviral defense system. By delivering the Cas9 nuclease complexed with 
      a synthetic guide RNA (gRNA) into a cell, the cell's genome can be cut at a desired 
      location, allowing existing genes to be removed and/or new ones added in vivo.
    */

    public Guid Id { get; set; }
    public Guid GeneId { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string CRISPRiStrain { get; set; }

  }
}