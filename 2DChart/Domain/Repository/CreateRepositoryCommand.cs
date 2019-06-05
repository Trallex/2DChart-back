using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace _2DChart.Domain.Repository
{
    public class CreateRepositoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<CreateRepositoryCommand, Guid>
        {
            public async Task<Guid> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
            {
                return Guid.NewGuid();
            }
        }
    }
}
