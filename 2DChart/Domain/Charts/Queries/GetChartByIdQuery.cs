﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Database;
using _2DChart.Domain.Function;
using _2DChart.Domain.Repository;

namespace _2DChart.Domain.Charts.Queries
{
    public class GetChartByIdQuery : IRequest<ChartDto>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<GetChartByIdQuery, ChartDto>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ChartDto> Handle(GetChartByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Chart.Where(ch => ch.ChartId == request.Id)
                    .Include(f => f.Functions)
                    .SingleOrDefaultAsync(cancellationToken);
                return result == null ? null : _mapper.Map<ChartDto>(result);
            }
        }
    }
}