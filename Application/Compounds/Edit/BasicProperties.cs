using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Compounds.DTOs;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Compounds.Edit
{
  public class BasicProperties
  {
    public class Command : IRequest<Result<Compound>>
    {
      public CompoundEditDTO EditedCompound { get; set; }
    }

    // public class CommandValidator : AbstractValidator<Command>
    // {
    //   public CommandValidator()
    //   {
    //     RuleFor(cmd => cmd.Gene).SetValidator(new GeneValidator());
    //   }

    // }

    public class Handler : IRequestHandler<Command, Result<Compound>>
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
      public async Task<Result<Compound>> Handle(Command request, CancellationToken cancellationToken)
      {

        /* check if compound evolution Id is correct */

        var existingCompound = await _context.Compounds.FirstOrDefaultAsync
          (c => c.Id == request.EditedCompound.Id);

        if (existingCompound == null)
        {
          return Result<Compound>.Failure("Invalid Compound Id" + request.EditedCompound.Id);
        }

        /* Allow modifying compound Smiles, MolArea and MolWeight Only  */

        /* Allow modifying compound MolArea and MolWeight Only  */
        existingCompound.MolArea = request.EditedCompound.MolArea;
        existingCompound.MolWeight = request.EditedCompound.MolWeight;
        existingCompound.Smile = request.EditedCompound.Smiles;

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;


        if (!success) return Result<Compound>.Failure("Failed to modify compound");
        return Result<Compound>.Success(existingCompound);
      }

    }
  }
}
