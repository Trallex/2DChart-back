using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Database;

namespace _2DChart.Domain.Repository.Commands
{
    public class AddChartToRepoCommand : IRequest<RepositoryDto>
    {
        public Guid RepoId { get; set; }
        public Guid ChartId { get; set; }
        public class Handler : IRequestHandler<AddChartToRepoCommand,RepositoryDto>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RepositoryDto> Handle(AddChartToRepoCommand request, CancellationToken cancellationToken)
            {
                var repo = await _context.Repository.FindAsync(request.RepoId);
                var chart = await _context.Chart.FindAsync(request.ChartId);
                if (repo == null || chart == null)
                    return null;
                chart.Repository = repo;
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<RepositoryDto>(repo);
            }
        }
    }
}
