using Application.Genes.DTOs;
using Domain;
using FluentValidation;

namespace Application.Genes
{
  public class GenePublicEditDTOValidator : AbstractValidator<GenePublicEditDTO>
  {
    public GenePublicEditDTOValidator()
    {
      RuleFor(gene => gene.GeneName).NotEmpty();
      RuleFor(gene => gene.AccessionNumber).NotEmpty();
    }

  }
}