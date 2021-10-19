using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Screens
{
    public class Details
    {
        public class Query : IRequest<Result<Screen>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Screen>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;

            }
            public async Task<Result<Screen>> Handle(Query request, CancellationToken cancellationToken)
            {
                var screen = await _context.Screens
                .Include(h => h.ValidatedHits)
                .Include(h => h.ScreenSequences)
                .FirstOrDefaultAsync(s => s.Id == request.Id);
                return Result<Screen>.Success(screen);
            }

        }

    }
}