using Domain;
using FluentValidation;

namespace Application.Genes
{
  public class GeneValidator : AbstractValidator<Gene>
  {
    public GeneValidator()
    {
      RuleFor(gene => gene.GeneName).NotEmpty();
      RuleFor(gene => gene.AccessionNumber).NotEmpty();
    }

  }
}