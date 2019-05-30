using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Models;
using _2DChart.Domain.Users.Queries;

namespace _2DChart.Domain.Charts
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
                    ChartId = Guid.NewGuid(),
                    CreationDate = DateTime.Today,
                    Functions = new List<FunctionDto>(),
                    Logo = "XDDD"

                };
            }
        }
    }
}
