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

        var GeneToEdit = await _context.Genes.FindAsync(request.Gene.Id);

        if (GeneToEdit == null) return null;

        _mapper.Map(request.Gene, GeneToEdit);

        var success = await _context.SaveChangesAsync(_userAccessor.GetUsername()) > 0;

        if (!success) return Result<Gene>.Failure("Failed to edit genome");

        return Result<Gene>.Success(GeneToEdit);

      }
    }
  }
}