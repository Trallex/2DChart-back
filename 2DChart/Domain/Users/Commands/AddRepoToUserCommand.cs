﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using _2DChart.Data.Database;
using _2DChart.Data.Models;
using _2DChart.Helpers;

namespace _2DChart.Domain.Users.Commands
{
    public class AddRepoToUserCommand : IRequest<CommandResult>
    {
        public Guid UserId { get; set; }
        public Guid RepoId { get; set; }

        public class Handler : IRequestHandler<AddRepoToUserCommand,CommandResult>
        {
            private readonly ChartDbContext _context;
            public Handler(ChartDbContext context)
            {
                _context = context;
            }

            public async Task<CommandResult> Handle(AddRepoToUserCommand request, CancellationToken cancellationToken)
            {
                if (await _context.User.FindAsync(request.UserId) == null || await _context.Repository.FindAsync(request.RepoId) == null)
                    return null;
                var userep = new UseRep
                {
                    RepId = request.RepoId,
                    UseId = request.UserId,
                    IsOwner = true
                };
                await _context.UseRep.AddAsync(userep,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return CommandResult.Success;
            }
        }
    }
}
