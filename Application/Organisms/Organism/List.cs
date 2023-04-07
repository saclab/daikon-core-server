using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Organisms
{
    public class List
    {
        public class Query : IRequest<Result<List<Organism>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Organism>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Organism>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var organisms = await _context.Organisms.Include(o => o.Strains)
                    .OrderBy(o => o.Name).ToListAsync();

                return Result<List<Organism>>.Success(organisms);
            }
        }
        
    }
}