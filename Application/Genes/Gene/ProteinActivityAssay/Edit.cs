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

namespace Application.Genes.ProteinActivityAssay
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneProteinActivityAssay>>
    {
      public GeneProteinActivityAssay GeneProteinActivityAssay { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneProteinActivityAssay>>
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
      public async Task<Result<GeneProteinActivityAssay>> Handle(Command request, CancellationToken cancellationToken)
      {



        // Check if gene essentiality exists
        var GeneProteinActivityAssayToEdit = await _context.GeneProteinActivityAssays.FirstOrDefaultAsync
            (g => g.Id == request.GeneProteinActivityAssay.Id);

        if (GeneProteinActivityAssayToEdit == null)
        {
          return Result<GeneProteinActivityAssay>.Failure("Invalid GeneProteinActivityAssay ID");
        }

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneProteinActivityAssay.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneProteinActivityAssay>.Failure("Invalid Gene ID");
        }

        _mapper.Map(request.GeneProteinActivityAssay, GeneProteinActivityAssayToEdit);
        GeneProteinActivityAssayToEdit.Id = request.GeneProteinActivityAssay.Id;
        GeneProteinActivityAssayToEdit.GeneId = BaseGene.Id;
        GeneProteinActivityAssayToEdit.GeneAccessionNumber = BaseGene.AccessionNumber;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneProteinActivityAssay>.Failure("Failed to edit gene essentiality.");
        return Result<GeneProteinActivityAssay>.Success(GeneProteinActivityAssayToEdit);

      }
    }
  }
}