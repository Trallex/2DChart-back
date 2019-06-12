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
    public class CreateFunctionCommand : IRequest<List<Parameter>>
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Approximation { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public class Handler : IRequestHandler<CreateFunctionCommand,List<Parameter>>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;
            private Equation _eqManager;
            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Parameter>> Handle(CreateFunctionCommand request,
                CancellationToken cancellationToken)
            {
                //TODO : eq manager need function to parse parameters into body
                var func = new org.mariuszgromada.math
                    .mxparser.Function(request.Body);
                var expr = new Expression(func.getFunctionExpressionString());
                expr.checkSyntax();
                var list = new List<Parameter>();
                var isCorect = func.checkSyntax();
        
                return list;
            }    
        }
    }
}
