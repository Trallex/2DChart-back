using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Database;
using _2DChart.Domain.Repository;

namespace _2DChart.Domain.Users.Queries
{
    public class GetUserReposQuery : IRequest<List<RepositoryDto>>
    {
        public Guid UserId { get; set; }
        public class Handler : IRequestHandler<GetUserReposQuery, List<RepositoryDto>>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<RepositoryDto>> Handle(GetUserReposQuery request, CancellationToken cancellationToken)
            {
                if (await _context.User.FindAsync(request.UserId) == null) return null;
                var repos = await _context.UseRep.Where(user => user.UseId == request.UserId).Include(r=>r.Rep).Select(rep=>rep.Rep)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<RepositoryDto>>(repos);
            }
        }
    }
}
