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
        newGenePublicData.GeneId = gid;
        GeneToCreate.GenePublicData = newGenePublicData;
        _context.GenePublicData.Add(newGenePublicData);

        // var newGeneNonPublicData = new GeneNonPublicData();
        // _mapper.Map(request.Gene.GeneNonPublicData, newGeneNonPublicData);
        // Guid newGeneNonPublicDataGid = Guid.NewGuid();
        // newGeneNonPublicData.Id = newGeneNonPublicDataGid;
        // newGeneNonPublicData.GeneId = gid;
        // GeneToCreate.GeneNonPublicData = newGeneNonPublicData;
        // _context.GeneNonPublicData.Add(newGeneNonPublicData);

        // var newGeneVulnerability = new GeneVulnerability();
        // _mapper.Map(request.Gene.GeneVulnerability, newGeneVulnerability);
        // newGeneVulnerability.Id = Guid.NewGuid();
        // newGeneVulnerability.GeneId = gid;
        // GeneToCreate.GeneVulnerability = newGeneVulnerability;
        // _context.GeneVulnerability.Add(newGeneVulnerability);


        _context.Genes.Add(GeneToCreate);
        

        var success = await _context.SaveChangesAsync() > 0;

        if (!success) return Result<Gene>.Failure("Failed to create Gene");
        return Result<Gene>.Success(GeneToCreate);

      }
    }
  }
}