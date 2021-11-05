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

namespace Application.Genes.UnpublishedStructures
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneUnpublishedStructures>>
    {
      public GeneUnpublishedStructures GeneUnpublishedStructures { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneUnpublishedStructures>>
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
      public async Task<Result<GeneUnpublishedStructures>> Handle(Command request, CancellationToken cancellationToken)
      {



        // Check if gene essentiality exists
        var GeneUnpublishedStructuresToEdit = await _context.GeneUnpublishedStructures.FirstOrDefaultAsync
            (g => g.Id == request.GeneUnpublishedStructures.Id);

        if (GeneUnpublishedStructuresToEdit == null)
        {
          return Result<GeneUnpublishedStructures>.Failure("Invalid GeneUnpublishedStructures ID");
        }

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneUnpublishedStructures.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneUnpublishedStructures>.Failure("Invalid Gene ID");
        }

        _mapper.Map(request.GeneUnpublishedStructures, GeneUnpublishedStructuresToEdit);
        GeneUnpublishedStructuresToEdit.Id = request.GeneUnpublishedStructures.Id;
        GeneUnpublishedStructuresToEdit.GeneId = BaseGene.Id;
        GeneUnpublishedStructuresToEdit.GeneAccessionNumber = BaseGene.AccessionNumber;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneUnpublishedStructures>.Failure("Failed to edit gene essentiality.");
        return Result<GeneUnpublishedStructures>.Success(GeneUnpublishedStructuresToEdit);

      }
    }
  }
}