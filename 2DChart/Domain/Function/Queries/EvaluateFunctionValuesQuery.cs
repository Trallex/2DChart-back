using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Domain.EquationMenager;

namespace _2DChart.Domain.Function.Queries
{
    public class EvaluateFunctionValuesQuery : IRequest<List<double>>
    {
        public Guid FunctionId { get; set; }

        public class Handler : IRequestHandler<EvaluateFunctionValuesQuery, List<double>>
        {
            private readonly ChartDbContext _context;
            private Equation _eqManager;
            public Handler(ChartDbContext context)
            {
                _context = context;
            }

            public async Task<List<double>> Handle(EvaluateFunctionValuesQuery request,
                CancellationToken cancellationToken)
            {
                var function = await _context.Function.FindAsync(request.FunctionId);
                if (function == null)
                {
                    return null;
                }
                // equation manager, input bodystring, min, max, approx -> return values List<double>
                _eqManager = new Equation(function);
                Task<List<double>> task = Task.Run(() => _eqManager.GetPoints(), cancellationToken);

                return task.Result;
            }
        }
    }
}