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

namespace Application.Genes.ProteinProduction
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneProteinProduction>>
    {
      public GeneProteinProduction GeneProteinProduction { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneProteinProduction>>
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
      public async Task<Result<GeneProteinProduction>> Handle(Command request, CancellationToken cancellationToken)
      {



        // Check if gene essentiality exists
        var GeneProteinProductionToEdit = await _context.GeneProteinProductions.FirstOrDefaultAsync
            (g => g.Id == request.GeneProteinProduction.Id);

        if (GeneProteinProductionToEdit == null)
        {
          return Result<GeneProteinProduction>.Failure("Invalid GeneProteinProduction ID");
        }

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneProteinProduction.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneProteinProduction>.Failure("Invalid Gene ID");
        }

        _mapper.Map(request.GeneProteinProduction, GeneProteinProductionToEdit);
        GeneProteinProductionToEdit.Id = request.GeneProteinProduction.Id;
        GeneProteinProductionToEdit.GeneId = BaseGene.Id;
        GeneProteinProductionToEdit.GeneAccessionNumber = BaseGene.AccessionNumber;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneProteinProduction>.Failure("Failed to edit gene protein production");
        return Result<GeneProteinProduction>.Success(GeneProteinProductionToEdit);

      }
    }
  }
}