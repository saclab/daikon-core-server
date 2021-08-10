using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Genes.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Batch.Gene
{
  public class MycobrowserPull
  {
    public class Command : IRequest<Result<Unit>> {}


    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
        _context = context;

      }
      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        Console.WriteLine(">>> Start Await: "); 
        await Task.Delay(5000);
        Console.WriteLine("<<< End Await: "); 
        return Result<Unit>.Success(Unit.Value);
      }

    }
  }
}