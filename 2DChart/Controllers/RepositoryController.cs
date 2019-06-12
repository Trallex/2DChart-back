using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2DChart.Domain.Charts;
using _2DChart.Domain.Repository;

namespace _2DChart.Controllers
{

    public class RepositoryController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RepositoryDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetRepositoryById(Guid id)
        {
            var result = await Mediator.Send(new GetRepoByIdQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{repoId}/charts")]
        [ProducesResponseType(typeof(List<ChartDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetRepoCharts(Guid repoId)
        {
            var result = await Mediator.Send(new GetRepoChartsQuery { RepoId = repoId });
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddRepository([FromBody] CreateRepositoryCommand request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("{repoId}/{chartId}")]
        [ProducesResponseType(typeof(RepositoryDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> AddChartToRepo(Guid repoId, Guid chartId)
        {
            var result = await Mediator.Send(new AddChartToRepoCommand { RepoId = repoId, ChartId = chartId });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }



    }
}