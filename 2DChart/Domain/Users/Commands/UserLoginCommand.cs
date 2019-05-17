using System.Threading;
using System.Threading.Tasks;
using MediatR;
using _2DChart.Data.Models;
using _2DChart.Domain.Services;

namespace _2DChart.Domain.Users.Commands
{
    public class UserLoginCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<UserLoginCommand, User>
        {
            private readonly UserService _userService;

            public Handler(UserService userService)
            {
                _userService = userService;
            }
            public async Task<User> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {

                var result = await _userService.Authenticate(request.Name, request.Password, cancellationToken);

                return result;
            }
        }
    }
}
