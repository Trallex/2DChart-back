using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Domain.Charts;
using _2DChart.Domain.Function;

namespace _2DChart.Domain.Repository
{
    public class GetRepoByIdQuery : IRequest<RepositoryDto>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<GetRepoByIdQuery, RepositoryDto>
        {
            private readonly ChartDbContext _context;

            public Handler(ChartDbContext context)
            {
                _context = context;
            }

            public async Task<RepositoryDto> Handle(GetRepoByIdQuery request, CancellationToken cancellationToken)
            {
                //TODO : Add mapper
                //                var result = await _context.Chart.FindAsync(request.Id);
                //                return result;

                return new RepositoryDto();
            }
        }
    }
}