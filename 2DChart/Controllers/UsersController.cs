using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _2DChart.Data.Models;
using _2DChart.Domain.Repository;
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
        [ProducesResponseType(typeof(RepositoryDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetUserRepos([FromBody] GetUserReposQuery request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }

        [HttpPost("{userId}/{repoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> AddRepoToUser(Guid userId, Guid repoId)
        {
            return Ok();
        }

    }
}