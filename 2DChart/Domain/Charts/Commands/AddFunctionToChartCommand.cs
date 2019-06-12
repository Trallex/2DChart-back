using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Domain.Repository;

namespace _2DChart.Domain.Charts.Commands
{
    public class AddFunctionToChartCommand : IRequest<ChartDto>
    {
        public Guid ChartId { get; set; }
        public Guid FunctionId { get; set; }
        public class Handler : IRequestHandler<AddFunctionToChartCommand,ChartDto>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ChartDto> Handle(AddFunctionToChartCommand request, CancellationToken cancellationToken)
            {
                var function = await _context.Function.FindAsync(request.FunctionId);
                var chart = await _context.Chart.FindAsync(request.ChartId);
                if (function == null || chart == null)
                    return null;
                function.Chart = chart;
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ChartDto>(chart);
            }
        }
    }
}
