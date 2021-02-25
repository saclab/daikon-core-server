using Domain;
using FluentValidation;

namespace Application.Genomes
{
  public class GenomeValidator : AbstractValidator<Genome>
  {
    public GenomeValidator()
    {
      RuleFor(genome => genome.GeneName).NotEmpty();
      RuleFor(genome => genome.AccessionNumber).NotEmpty();
    }

  }
}