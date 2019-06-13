using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Domain.EquationMenager;

namespace _2DChart.Domain.Function.Commands
{
    public class UpdateFunctionCommand : IRequest<FunctionDto>
    {
        public Guid FunctionId { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
        public int? Approximation { get; set; }
        public string FunctionString { get; set; }
        public class Handler : IRequestHandler<UpdateFunctionCommand,FunctionDto>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FunctionDto> Handle(UpdateFunctionCommand request, CancellationToken cancellationToken)
            {
                var function = await _context.Function.FindAsync(request.FunctionId);
                if (function == null)
                    return null;

                if (request.Approximation != null) function.Approximation = (int) request.Approximation;
                if (request.Min != null) function.Min = (double) request.Min;
                if (request.Max != null) function.Min = (double) request.Max;

                _context.Update(function);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<FunctionDto>(function);
            }
        }
    }
}
