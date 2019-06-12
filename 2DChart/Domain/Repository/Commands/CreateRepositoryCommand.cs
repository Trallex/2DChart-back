using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Database;

namespace _2DChart.Domain.Repository.Commands
{
    public class CreateRepositoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<CreateRepositoryCommand, Guid>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
            {
                var repo = new Data.Models.Repository
                {
                    Name = request.Name,
                    Description = request.Description,
                    CreationDate = DateTime.Now
                };
                await _context.Repository.AddAsync(repo,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return repo.RepositoryId;
            }
        }
    }
}
