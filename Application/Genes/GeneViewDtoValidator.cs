using Application.Genes.DTOs;
using Domain;
using FluentValidation;

namespace Application.Genes
{
  public class GeneViewDtoValidator : AbstractValidator<GeneViewDTO>
  {
    public GeneViewDtoValidator()
    {
      RuleFor(geneViewDto => geneViewDto.GeneName).NotEmpty();
      RuleFor(geneViewDto => geneViewDto.AccessionNumber).NotEmpty();
    }

  }
}