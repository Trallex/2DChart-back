using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _2DChart.Data.Models;
using _2DChart.Domain.Repository;
using _2DChart.Domain.Repository.Queries;
using _2DChart.Domain.Users.Commands;
using _2DChart.Domain.Users.Queries;

namespace _2DChart.Controllers
{
    public class UsersController : BaseController
    {
        //For testing purposes
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var result = await Mediator.Send(new GetUsersQuery());
            return Ok(result);
        }

       
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> LoginUser([FromBody] UserLoginCommand login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await Mediator.Send(login);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> RegisterUser([FromBody] UserRegisterCommand register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await Mediator.Send(register);
            return Ok(result);
        }
        [HttpGet("{userId}/repos")]
        [ProducesResponseType(typeof(List<RepositoryDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetUserRepos(Guid userId)
        {   var result = await Mediator.Send(new GetUserReposQuery {UserId = userId});
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("{userId}/{repoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> AddRepoToUser(Guid userId, Guid repoId)
        {
            var result = await Mediator.Send(new AddRepoToUserCommand {RepoId = repoId, UserId = userId});
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{userId}/{repoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteUserRepo(Guid userId, Guid repoId)
        {
            var user = await Mediator.Send(new GetUserQuery {UserId = userId});
            var repo = await Mediator.Send(new GetRepoByIdQuery {Id = repoId});
            if (user == null || repo == null) return NotFound();
            await Mediator.Send(new DeleteUserRepoCommand {RepoId = user.Guid, UserId = user.Guid});
            return Ok();
        }


    }
}