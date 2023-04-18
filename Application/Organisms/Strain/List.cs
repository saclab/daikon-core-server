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

namespace Application.Strains
{
    public class List
    {
        public class Query : IRequest<Result<List<Strain>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Strain>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Strain>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var strains = await _context.Strains
                    .OrderBy(o => o.Name).ToListAsync();

                return Result<List<Strain>>.Success(strains);
            }
        }
        
    }
}