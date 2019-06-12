using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using _2DChart.Data.Database;

namespace _2DChart.Domain.Function.Queries
{
    public class EvaluateFunctionValuesQuery : IRequest<List<double>>
    {
        public Guid FunctionId { get; set; }

        public class Handler : IRequestHandler<EvaluateFunctionValuesQuery, List<double>>
        {
            private readonly ChartDbContext _context;

            public Handler(ChartDbContext context)
            {
                _context = context;
            }

            public async Task<List<double>> Handle(EvaluateFunctionValuesQuery request,
                CancellationToken cancellationToken)
            {
                var function = await _context.Function.FindAsync(request.FunctionId, cancellationToken);
                if (function == null)
                {
                    return null;
                }
                // equation manager, input bodystring, min, max, approx -> return values List<double>
                
            

                return new List<double>();
            }
        }
    }
}