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

namespace Application.Genes.ResistanceMutation
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneResistanceMutation>>
    {
      public GeneResistanceMutation GeneResistanceMutation { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneResistanceMutation>>
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
      public async Task<Result<GeneResistanceMutation>> Handle(Command request, CancellationToken cancellationToken)
      {



        // Check if gene essentiality exists
        var GeneResistanceMutationToEdit = await _context.GeneResistanceMutations.FirstOrDefaultAsync
            (g => g.Id == request.GeneResistanceMutation.Id);

        if (GeneResistanceMutationToEdit == null)
        {
          return Result<GeneResistanceMutation>.Failure("Invalid GeneResistanceMutation ID");
        }

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneResistanceMutation.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneResistanceMutation>.Failure("Invalid Gene ID");
        }

        _mapper.Map(request.GeneResistanceMutation, GeneResistanceMutationToEdit);
        GeneResistanceMutationToEdit.Id = request.GeneResistanceMutation.Id;
        GeneResistanceMutationToEdit.GeneId = BaseGene.Id;
        GeneResistanceMutationToEdit.GeneAccessionNumber = BaseGene.AccessionNumber;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneResistanceMutation>.Failure("Failed to edit gene essentiality.");
        return Result<GeneResistanceMutation>.Success(GeneResistanceMutationToEdit);

      }
    }
  }
}