using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes.CRISPRiStrain
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneCRISPRiStrain>>
    {
      public GeneCRISPRiStrain GeneCRISPRiStrain { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneCRISPRiStrain>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _context = context;
        _mapper = mapper;
        _userAccessor = userAccessor;
      }
      public async Task<Result<GeneCRISPRiStrain>> Handle(Command request, CancellationToken cancellationToken)
      {



        // Check if gene essentiality exists
        var GeneCRISPRiStrainToEdit = await _context.GeneCRISPRiStrains.FirstOrDefaultAsync
            (g => g.Id == request.GeneCRISPRiStrain.Id);

        if (GeneCRISPRiStrainToEdit == null)
        {
          return Result<GeneCRISPRiStrain>.Failure("Invalid GeneCRISPRiStrain ID");
        }

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneCRISPRiStrain.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneCRISPRiStrain>.Failure("Invalid Gene ID");
        }

        _mapper.Map(request.GeneCRISPRiStrain, GeneCRISPRiStrainToEdit);
        GeneCRISPRiStrainToEdit.Id = request.GeneCRISPRiStrain.Id;
        GeneCRISPRiStrainToEdit.GeneId = BaseGene.Id;
        GeneCRISPRiStrainToEdit.GeneAccessionNumber = BaseGene.AccessionNumber;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneCRISPRiStrain>.Failure("Failed to edit gene essentiality.");
        return Result<GeneCRISPRiStrain>.Success(GeneCRISPRiStrainToEdit);

      }
    }
  }
}