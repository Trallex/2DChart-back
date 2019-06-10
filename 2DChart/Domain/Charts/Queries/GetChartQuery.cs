using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Domain.Function;

namespace _2DChart.Domain.Charts.Queries
{
    public class GetChartQuery : IRequest<ChartDto>
    {
        public class Handler : IRequestHandler<GetChartQuery, ChartDto>
        {
            private readonly ChartDbContext _context;

            public Handler(ChartDbContext context)
            {
                _context = context;
            }

            public async Task<ChartDto> Handle(GetChartQuery request, CancellationToken cancellationToken)
            {
                return new ChartDto
                {
                    Guid = Guid.NewGuid(),
                    CreationDate = DateTime.Today,
                    Functions = new List<ChartDto.FunctionListDto>(),
                    Name = "XDDD"

                };
            }
        }
    }
}
