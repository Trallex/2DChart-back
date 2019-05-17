using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using _2DChart.Data.Models;
using _2DChart.Domain.Services;

namespace _2DChart.Domain.Users.Commands
{
    public class UserRegisterCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public class Handler : IRequestHandler<UserRegisterCommand, User>
        {
            private readonly UserService _userService;

            public Handler(UserService userService)
            {
                _userService = userService;
            }
            public async Task<User> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {

                var result = await _userService.Create(request.Name, request.Password,request.Mail,cancellationToken);

                return result;
            }
        }
    }
}
