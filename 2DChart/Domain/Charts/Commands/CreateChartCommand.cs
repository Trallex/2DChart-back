using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace _2DChart.Domain.Charts.Commands
{
    public class CreateChartCommand : IRequest<Guid>
    {
        public class Handler : IRequestHandler<CreateChartCommand,Guid>
        {
            public async Task<Guid> Handle(CreateChartCommand request, CancellationToken cancellationToken)
            {
                return Guid.NewGuid();
            }
        }
    }
}
