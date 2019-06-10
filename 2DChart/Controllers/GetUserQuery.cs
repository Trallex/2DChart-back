using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Database;
using _2DChart.Domain.Users.Commands;

namespace _2DChart.Controllers
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }

        public class Handler : IRequestHandler<GetUserQuery, UserDto>
        {
            private readonly ChartDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ChartDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {  
                return _mapper.Map<UserDto>(await _context.User.FindAsync(request.UserId, cancellationToken));
            }
        }
    }
}