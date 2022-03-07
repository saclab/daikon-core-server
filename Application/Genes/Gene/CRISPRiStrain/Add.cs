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

namespace Application.Genes.CRISPRiStrain
{
  public class Add
  {
    public class Command : IRequest<Result<GeneCRISPRiStrain>>
    {
      public GeneCRISPRiStrain GeneCRISPRiStrain { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        //RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
      }

    }

    public class Handler : IRequestHandler<Command, Result<GeneCRISPRiStrain>>
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
      public async Task<Result<GeneCRISPRiStrain>> Handle(Command request, CancellationToken cancellationToken)
      {
        // Task.Delay(5000).Wait(); // Wait 2 seconds with blocking
        Guid gid = Guid.NewGuid();

        // First ferch Base Gene
        var BaseGene = await _context.Genes.FirstOrDefaultAsync
           (g => g.Id == request.GeneCRISPRiStrain.GeneId);
        if (BaseGene == null)
        {
          return Result<GeneCRISPRiStrain>.Failure("Invalid Gene ID");
        }

        var newGeneCRISPRiStrain = new GeneCRISPRiStrain();
        _mapper.Map(request.GeneCRISPRiStrain, newGeneCRISPRiStrain);
        newGeneCRISPRiStrain.Id = gid;
        newGeneCRISPRiStrain.GeneId = BaseGene.Id;
        newGeneCRISPRiStrain.GeneAccessionNumber = BaseGene.AccessionNumber;
        newGeneCRISPRiStrain.CreatedAt = DateTime.UtcNow;
        newGeneCRISPRiStrain.CreatedBy =  _userAccessor.GetUsername();


        // Add reference to base gene
        // 1. If no essentiality exists, create a new list
        if (BaseGene.GeneCRISPRiStrain == null)
        {
          BaseGene.GeneCRISPRiStrain = new List<GeneCRISPRiStrain>();
        }

        BaseGene.GeneCRISPRiStrain.Add(newGeneCRISPRiStrain);

        _context.GeneCRISPRiStrains.Add(newGeneCRISPRiStrain);


        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<GeneCRISPRiStrain>.Failure("Failed to create Genome");
        return Result<GeneCRISPRiStrain>.Success(newGeneCRISPRiStrain);

      }
    }
  }
}