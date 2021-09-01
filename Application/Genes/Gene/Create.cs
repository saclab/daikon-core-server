using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Genes
{
  public class Create
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
      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;
      }
      public async Task<Result<Gene>> Handle(Command request, CancellationToken cancellationToken)
      {
        Guid gid = Guid.NewGuid();
        var GeneToCreate = new Gene
        {
          Id = gid,
          AccessionNumber = request.Gene.AccessionNumber,
          GeneName = request.Gene.GeneName,
          Function = request.Gene.Function,
          Product = request.Gene.Product,
          FunctionalCategory = request.Gene.FunctionalCategory
        };

        var newGenePublicData = new GenePublicData();
         _mapper.Map(request.Gene.GenePublicData, newGenePublicData);
        Guid newGenePublicDataGid = Guid.NewGuid();
        newGenePublicData.Id = newGenePublicDataGid;
        newGenePublicData.Gene = GeneToCreate;
        newGenePublicData.GeneID = gid;
        GeneToCreate.GenePublicData = newGenePublicData;

        var newGeneNonPublicData = new GeneNonPublicData();
        _mapper.Map(request.Gene.GeneNonPublicData, newGeneNonPublicData);
        Guid newGeneNonPublicDataGid = Guid.NewGuid();
        newGeneNonPublicData.Id = newGeneNonPublicDataGid;
        newGeneNonPublicData.Gene = GeneToCreate;
        newGeneNonPublicData.GeneID = gid;
        GeneToCreate.GeneNonPublicData = newGeneNonPublicData;

        

        _context.Genes.Add(GeneToCreate);
        _context.GenePublicData.Add(newGenePublicData);
        _context.GeneNonPublicData.Add(newGeneNonPublicData);

        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<Gene>.Failure("Failed to create Genome");
        return Result<Gene>.Success(GeneToCreate);

      }
    }
  }
}