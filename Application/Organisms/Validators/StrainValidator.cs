using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Organisms.Validators
{
    public class StrainValidator : AbstractValidator<Strain>
    {
        public StrainValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(s => s.CanonicalName).NotEmpty().WithMessage("CanonicalName is required");
            RuleFor(s => s.OrganismId).NotEmpty().WithMessage("OrganismId is required");
            
        }
        
    }
}