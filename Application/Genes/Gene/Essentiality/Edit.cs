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

namespace Application.Genes.Essentiality
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneEssentiality>>
    {
      public GeneEssentiality GeneEssentiality { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneEssentiality>>
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
      public async Task<Result<GeneEssentiality>> Handle(Command request, CancellationToken cancellationToken)
      {



        // Check if gene essentiality exists
        var GeneEssentialityToEdit = await _context.GeneEssentiality.FirstOrDefaultAsync
            (g => g.Id == request.GeneEssentiality.Id);

        if (GeneEssentialityToEdit == null)
        {
          return Result<GeneEssentiality>.Failure("Invalid GeneEssentiality ID");
        }

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneEssentiality.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneEssentiality>.Failure("Invalid Gene ID");
        }

        _mapper.Map(request.GeneEssentiality, GeneEssentialityToEdit);
        GeneEssentialityToEdit.Id = request.GeneEssentiality.Id;
        GeneEssentialityToEdit.GeneId = BaseGene.Id;
        GeneEssentialityToEdit.GeneAccessionNumber = BaseGene.AccessionNumber;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneEssentiality>.Failure("Failed to edit gene essentiality.");
        return Result<GeneEssentiality>.Success(GeneEssentialityToEdit);

      }
    }
  }
}