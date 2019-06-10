using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Data.Models;

namespace _2DChart.Domain.Charts.Commands
{
    public class CreateChartCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public class Handler : IRequestHandler<CreateChartCommand, Guid>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(CreateChartCommand request, CancellationToken cancellationToken)
            {
                var chart = new Chart
                {
                    Logo = request.Name
                };

                await _context.Chart.AddAsync(chart,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return chart.ChartId;
            }
        }
    }
}
