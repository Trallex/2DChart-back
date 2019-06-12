using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
using org.mariuszgromada.math.mxparser;
using _2DChart.Data.Database;
using _2DChart.Data.Models;
using _2DChart.Domain.EquationMenager;

namespace _2DChart.Domain.Function.Commands
{
    public class CreateFunctionCommand : IRequest<Guid>
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Approximation { get; set; }
        public string Name { get; set; }
        public string FunctionString { get; set; }

        public class Handler : IRequestHandler<CreateFunctionCommand,Guid>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;
            private Equation _eqManager;
            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateFunctionCommand request,
                CancellationToken cancellationToken)
            {
               //check syntax
                var function = new Data.Models.Function
                {
                    CreationDate = DateTime.Now,
                    Approximation = request.Approximation,
                    FunctionString = request.FunctionString,
                    Min = request.Min,
                    Max = request.Max,
                    Name = request.Name
                };
                await _context.AddAsync(function,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return function.FunctionId;
            }    
        }
    }
}
