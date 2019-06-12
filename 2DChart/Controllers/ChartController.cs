using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2DChart.Domain.Charts;
using _2DChart.Domain.Charts.Commands;
using _2DChart.Domain.Charts.Queries;
using _2DChart.Domain.Function;

namespace _2DChart.Controllers
{

    public class ChartController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ChartDto), 200)]
        public async Task<ActionResult> GetMockChart()
        {
            var result = await Mediator.Send(new GetChartQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ChartDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetChartById(Guid id)
        {
            var result = await Mediator.Send(new GetChartByIdQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}/functions")]
        [ProducesResponseType(typeof(List<FunctionDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetChartFunctions(Guid id)
        {
            var result = await Mediator.Send(new GetChartFunctionsQuery { ChartId = id });
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddChart([FromBody] CreateChartCommand request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("{chartId}/{functionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddFunctionToChart(Guid chartId, Guid functionId)
        {
            var result = await Mediator.Send(new AddFunctionToChartCommand { ChartId = chartId, FunctionId = functionId });
            return result == null ? (ActionResult)NotFound() : Ok();
        }


    }
}