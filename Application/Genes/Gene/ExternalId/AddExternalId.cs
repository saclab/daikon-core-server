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
using System.Collections.Generic;
using System.Linq;

namespace Application.Genes
{
  public class AddExternalId
  {
    public class Command : IRequest<Result<GeneExternalId>>
    {
      public GeneExternalId GeneExternalId { get; set; }
    }


    public class CommandValidator : AbstractValidator<Command>
    {
      // public CommandValidator()
      // {
      //   RuleFor(cmd => cmd.GenePublicEditDTO).SetValidator(new GenePublicEditDTOValidator());
      // }

    }

    public class Handler : IRequestHandler<Command, Result<GeneExternalId>>
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
      public async Task<Result<GeneExternalId>> Handle(Command request, CancellationToken cancellationToken)
      {

        var geneToEdit = await _context.Genes
          .Include(g => g.GeneExternalIds)
          .FirstOrDefaultAsync(g => g.AccessionNumber == request.GeneExternalId.GeneAccessionNumber);

        Console.WriteLine("Gene to Edit=");
        Console.WriteLine(geneToEdit);


        if (geneToEdit == null) return null;

        var geneExternalIdToAdd = new GeneExternalId
        {
          Id = Guid.NewGuid(),
          GeneId = geneToEdit.Id,
          GeneAccessionNumber = geneToEdit.AccessionNumber,
          ExternalIdRef = request.GeneExternalId.ExternalIdRef,
          ExternalId = request.GeneExternalId.ExternalId
        };

        if (geneToEdit.GeneExternalIds == null)
        {
          geneToEdit.GeneExternalIds = new List<GeneExternalId>();
          geneToEdit.GeneExternalIds.Add(geneExternalIdToAdd);
          _context.GeneExternalIds.Add(geneExternalIdToAdd);
        }
        else
        {
          var externalRef = geneToEdit.GeneExternalIds.FirstOrDefault(i => i.ExternalIdRef == request.GeneExternalId.ExternalIdRef);
          if (externalRef == null)
          {
            geneToEdit.GeneExternalIds.Add(geneExternalIdToAdd);
            _context.GeneExternalIds.Add(geneExternalIdToAdd);
          }
          else
          {
            geneExternalIdToAdd.Id = externalRef.Id;
            externalRef.ExternalId = request.GeneExternalId.ExternalId;
          }

        }

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;
        Console.WriteLine("Success??");
        Console.WriteLine(success);

        if (!success) return Result<GeneExternalId>.Failure("Failed to add external ID");
        return Result<GeneExternalId>.Success(geneExternalIdToAdd);

      }
    }
  }
}