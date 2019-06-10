using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Database;
using _2DChart.Domain.Charts;

namespace _2DChart.Domain.Repository
{
    public class GetRepoChartsQuery : IRequest<List<ChartDto>>
    {
        public Guid RepoId { get; set; }

        public class Handler : IRequestHandler<GetRepoChartsQuery, List<ChartDto>>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ChartDto>> Handle(GetRepoChartsQuery request, CancellationToken cancellationToken)
            {
                var repo = await _context.Repository.Where(r=>r.RepositoryId == request.RepoId)
                    .Include(c=>c.Charts).FirstOrDefaultAsync(cancellationToken);
                return repo == null ? null : _mapper.Map<List<ChartDto>>(repo.Charts);
            }
        }
    }
}
