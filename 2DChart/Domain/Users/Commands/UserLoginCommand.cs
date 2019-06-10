using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Models;
using _2DChart.Domain.Services;

namespace _2DChart.Domain.Users.Commands
{
    public class UserLoginCommand : IRequest<UserDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<UserLoginCommand, UserDto>
        {
            private readonly UserService _userService;
            private readonly IMapper _mapper;

            public Handler(UserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }
            public async Task<UserDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {

                var result = await _userService.Authenticate(request.Name, request.Password, cancellationToken);

                return _mapper.Map<UserDto>(result);
            }
        }
    }
}
