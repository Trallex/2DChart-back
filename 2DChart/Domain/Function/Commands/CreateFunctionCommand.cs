using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace _2DChart.Domain.Function.Commands
{
    public class CreateFunctionCommand : IRequest<Guid>
    {
        public class Handler : IRequestHandler<CreateFunctionCommand,Guid>
        {
            public async Task<Guid> Handle(CreateFunctionCommand request, CancellationToken cancellationToken)
            {
                return Guid.NewGuid();
            }
        }
    }
}
