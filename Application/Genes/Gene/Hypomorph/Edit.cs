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

namespace Application.Genes.Hypomorph
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneHypomorph>>
    {
      public GeneHypomorph GeneHypomorph { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneHypomorph>>
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
      public async Task<Result<GeneHypomorph>> Handle(Command request, CancellationToken cancellationToken)
      {



        // Check if gene essentiality exists
        var GeneHypomorphToEdit = await _context.GeneHypomorphs.FirstOrDefaultAsync
            (g => g.Id == request.GeneHypomorph.Id);

        if (GeneHypomorphToEdit == null)
        {
          return Result<GeneHypomorph>.Failure("Invalid GeneHypomorph ID");
        }

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneHypomorph.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneHypomorph>.Failure("Invalid Gene ID");
        }

        _mapper.Map(request.GeneHypomorph, GeneHypomorphToEdit);
        GeneHypomorphToEdit.Id = request.GeneHypomorph.Id;
        GeneHypomorphToEdit.GeneId = BaseGene.Id;
        GeneHypomorphToEdit.GeneAccessionNumber = BaseGene.AccessionNumber;


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneHypomorph>.Failure("Failed to edit gene hypomorph.");
        return Result<GeneHypomorph>.Success(GeneHypomorphToEdit);

      }
    }
  }
}