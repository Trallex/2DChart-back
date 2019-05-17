using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Models;

namespace _2DChart.Domain.Users.Queries
{
    public class GetUsersQuery : IRequest<List<User>>
    {
        public class Handler : IRequestHandler<GetUsersQuery, List<User>>
        {
            private readonly ChartDbContext _context;

            public Handler(ChartDbContext context)
            {
                _context = context;
            }

            public Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return _context.User.ToListAsync(cancellationToken);
            }
        }
    }
}
