using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain.Question;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Genes.Promotion
{
  public class Questionaire
  {
    public class Query : IRequest<Result<List<Question>>> { }


    public class Handler : IRequestHandler<Query, Result<List<Question>>>
    {
      private readonly DataContext _context;
      
      public Handler(DataContext context)
      {
       
        _context = context;

      }
      public async Task<Result<List<Question>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var genePromotionQustionaire = await _context.Questions.Where(
            q => q.Module == "TargetPromotionQuestions")
            .ToListAsync();

        return Result<List<Question>>.Success(genePromotionQustionaire);
      }
    }
  }
}