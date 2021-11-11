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
      public GenePublicEditDTO GenePublicEditDTO { get; set; }
    }


    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(cmd => cmd.GenePublicEditDTO).SetValidator(new GenePublicEditDTOValidator());
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
          .Include(g => g.GenePublicData)
          .FirstOrDefaultAsync(g => g.Id == request.GenePublicEditDTO.Id);

        Console.WriteLine("Gene to Edit=");
        Console.WriteLine(geneToEdit);


        if (geneToEdit == null) return null;

        var genePublicDataId = geneToEdit?.GenePublicData?.Id;

        Console.WriteLine("Gene to genePublicDataId=");
        Console.WriteLine(genePublicDataId);

        geneToEdit.Function = request.GenePublicEditDTO.Function;

        if (genePublicDataId == null)
        {
          var newGenePublicData = new GenePublicData();
          _mapper.Map(request.GenePublicEditDTO.GenePublicData, geneToEdit.GenePublicData);

          newGenePublicData.GeneId = geneToEdit.Id;
          geneToEdit.GenePublicData = newGenePublicData;

          _context.GenePublicData.Add(newGenePublicData);
        }
        else
        {
          //geneToEdit.GenePublicData.Id = (Guid)genePublicDataId;
          _mapper.Map(request.GenePublicEditDTO.GenePublicData, geneToEdit.GenePublicData);
          geneToEdit.GenePublicData.GeneId = geneToEdit.Id;
        }

        Console.WriteLine("Made it till here, writing");



        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;
        Console.WriteLine("Success??");
        Console.WriteLine(success);



        if (!success) return Result<Gene>.Failure("Failed to edit genome");
        return Result<Gene>.Success(geneToEdit);

      }



    }
  }
}