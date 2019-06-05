using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Domain.Function;

namespace _2DChart.Domain.Charts.Queries
{
    public class GetChartByIdQuery : IRequest<ChartDto>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<GetChartByIdQuery, ChartDto>
        {
            private readonly ChartDbContext _context;

            public Handler(ChartDbContext context)
            {
                _context = context;
            }

            public async Task<ChartDto> Handle(GetChartByIdQuery request, CancellationToken cancellationToken)
            {
                //TODO : Add mapper
//                var result = await _context.Chart.FindAsync(request.Id);
//                return result;
                return new ChartDto
                {
                    Guid = Guid.NewGuid(),
                    CreationDate = DateTime.Today,
                    Functions = new List<FunctionDto>(),
                    Name = "XDDD"

                };
            }
        }
    }
}