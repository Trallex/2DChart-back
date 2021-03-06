﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using _2DChart.Data.Models;
using _2DChart.Domain.Services;

namespace _2DChart.Domain.Users.Commands
{
    public class UserRegisterCommand : IRequest<UserDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public class Handler : IRequestHandler<UserRegisterCommand, UserDto>
        {
            private readonly UserService _userService;
            private readonly IMapper _mapper;

            public Handler(UserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }
            public async Task<UserDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {

                var result = await _userService.Create(request.Name, request.Password,request.Mail,cancellationToken);

                return _mapper.Map<UserDto>(result);
            }
        }
    }
}
