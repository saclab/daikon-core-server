using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.YAMLDTOs
{
  public class YAMLStrainDTO
  {
    public Guid Id { get; set; }
    public Guid OrganismId { get; set; }
    public string OrganismCanonicalName { get; set; }
    public string Name { get; set; }
    public string CanonicalName { get; set; }
    public string Description { get; set; }
    public string GenomeSequence { get; set; }
    public int DrugResistanceLevel { get; set; }
  }
}