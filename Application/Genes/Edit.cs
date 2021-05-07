using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
// Entity framework core is required for 'include'
using Microsoft.EntityFrameworkCore;
using Application.Genes.DTOs;

namespace Application.Genes
{
  public class Edit
  {
    public class Command : IRequest<Result<GeneViewDTO>>
    {
      public Gene Gene { get; set; }
    }


    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneViewDTO>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
      {
        _userAccessor = userAccessor;
        _mapper = mapper;
        _context = context;
      }
      public async Task<Result<GeneViewDTO>> Handle(Command request, CancellationToken cancellationToken)
      {

        var geneToEdit = await _context.Genes
          .Include(p => p.GenePublicData)
          .Include(p => p.GeneNonPublicData)
          .FirstOrDefaultAsync(g => g.Id == request.Gene.Id);


        if (geneToEdit == null) return null;
        // maintain IDs
        var geneId = geneToEdit.Id;
        var geneNonPublicDataId = geneToEdit.GeneNonPublicData.Id;
        var geneNonPublicDataRef = geneToEdit.GeneNonPublicData.Gene;
        var genePublicDataId = geneToEdit.GenePublicData.Id;
        var genePublicDataRef = geneToEdit.GenePublicData.Gene;
        
        _mapper.Map(request.Gene, geneToEdit);

        // This would ensure primary ids are maintained and does not depend on the user's request.
        geneToEdit.Id = geneId;

        geneToEdit.GeneNonPublicData.Id = geneNonPublicDataId;
        geneToEdit.GeneNonPublicData.GeneID = geneId;
        geneToEdit.GeneNonPublicData.Gene = geneNonPublicDataRef;

        geneToEdit.GenePublicData.Id = genePublicDataId;
        geneToEdit.GenePublicData.GeneID = geneId;
        geneToEdit.GenePublicData.Gene = genePublicDataRef;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;
        var geneMapped = _mapper.Map<GeneViewDTO>(geneToEdit);

        if (!success) return Result<GeneViewDTO>.Failure("Failed to edit genome");
        return Result<GeneViewDTO>.Success(geneMapped);

      }
    }
  }
}