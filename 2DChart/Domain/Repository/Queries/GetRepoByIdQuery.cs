using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Database;

namespace _2DChart.Domain.Repository.Queries
{
    public class GetRepoByIdQuery : IRequest<RepositoryDto>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<GetRepoByIdQuery, RepositoryDto>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RepositoryDto> Handle(GetRepoByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Repository.Where(repo => repo.RepositoryId == request.Id)
                    .Include(c => c.Charts).SingleOrDefaultAsync(cancellationToken);
                return result == null ? null : _mapper.Map<RepositoryDto>(result);
            }
        }
    }
}