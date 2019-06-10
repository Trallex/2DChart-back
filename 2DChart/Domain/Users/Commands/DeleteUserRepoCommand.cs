using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Database;
using _2DChart.Data.Models;

namespace _2DChart.Domain.Users.Commands
{
    public class DeleteUserRepoCommand:IRequest
    {
        public Guid UserId { get; set; }
        public Guid RepoId { get; set; }

        public class Handler : AsyncRequestHandler<DeleteUserRepoCommand>
        {
            private readonly ChartDbContext _context;
            public Handler(ChartDbContext context)
            {
                _context = context;
            }


            protected override async Task Handle(DeleteUserRepoCommand request, CancellationToken cancellationToken)
            {
                var userep = await _context.UseRep.Where(u => u.UseId == request.UserId)
                    .Where(r => r.RepId == request.RepoId).SingleOrDefaultAsync(cancellationToken);
                _context.UseRep.Remove(userep);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
