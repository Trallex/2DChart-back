using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Database;
using _2DChart.Domain.Function;

namespace _2DChart.Domain.Charts.Queries
{
    public class GetChartFunctionsQuery : IRequest<List<FunctionDto>>
    {
        public Guid ChartId { get; set; }
        public class Handler : IRequestHandler<GetChartFunctionsQuery,List<FunctionDto>>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FunctionDto>> Handle(GetChartFunctionsQuery request, CancellationToken cancellationToken)
            {
                var chart = await _context.Chart.Where(ch => ch.ChartId == request.ChartId)
                    .Include(c => c.Functions)
                    .SingleOrDefaultAsync(cancellationToken);
                if (chart == null) return null;

                return _mapper.Map<List<FunctionDto>>(chart.Functions);
            }
        }
    }
}
