using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Organisms.Validators
{
  public class OrganismValidator : AbstractValidator<Organism>
  {
    public OrganismValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.CanonicalName).NotEmpty().WithMessage("CanonicalName is required");
    }
  }
}