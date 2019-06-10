using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
            private readonly IMapper _mapper;

            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RepositoryDto> Handle(GetRepoByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Chart.FindAsync(request.Id);
                return result == null ? null : _mapper.Map<RepositoryDto>(result);
            }
        }
    }
}