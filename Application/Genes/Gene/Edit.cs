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
    public class Command : IRequest<Result<Gene>>
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

    public class Handler : IRequestHandler<Command, Result<Gene>>
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
      public async Task<Result<Gene>> Handle(Command request, CancellationToken cancellationToken)
      {

        var geneToEdit = await _context.Genes
          .Include(p => p.GenePublicData)
          .Include(p => p.GeneNonPublicData)
          .FirstOrDefaultAsync(g => g.Id == request.Gene.Id);


        if (geneToEdit == null) return null;
        // maintain IDs
        //var geneId = geneToEdit.Id;
        
        var genePublicDataId = geneToEdit?.GenePublicData?.Id;
       
        var geneNonPublicDataId = geneToEdit?.GeneNonPublicData?.Id;
        
        _mapper.Map(request.Gene, geneToEdit);

        // This would ensure primary ids are maintained and does not depend on the user's request.
        //geneToEdit.Id = geneId;

        //geneToEdit.GenePublicData.Id = genePublicDataId;
        //geneToEdit.GenePublicData.GeneId = geneId;
       


        if (geneNonPublicDataId == null)
        {
          var newGeneNonPublicData = new GeneNonPublicData();
          _mapper.Map(request.Gene.GeneNonPublicData, newGeneNonPublicData);
         
          newGeneNonPublicData.GeneId = geneToEdit.Id;
          geneToEdit.GeneNonPublicData = newGeneNonPublicData;

          _context.GeneNonPublicData.Add(newGeneNonPublicData);
        }
        else
        {
          // geneToEdit.GeneNonPublicData.Id = (Guid)geneNonPublicDataId;
          geneToEdit.GeneNonPublicData.GeneId = geneToEdit.Id;
        }

        if (genePublicDataId == null)
        {
          var newGenePublicData = new GenePublicData();
          _mapper.Map(request.Gene.GenePublicData, newGenePublicData);
         
          newGenePublicData.GeneId = geneToEdit.Id;
          geneToEdit.GenePublicData = newGenePublicData;

          _context.GenePublicData.Add(newGenePublicData);
        }
        else
        {
          // geneToEdit.GeneNonPublicData.Id = (Guid)geneNonPublicDataId;
          geneToEdit.GenePublicData.GeneId = geneToEdit.Id;
        }



        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;
       

        if (!success) return Result<Gene>.Failure("Failed to edit genome");
        return Result<Gene>.Success(geneToEdit);

      }



    }
  }
}