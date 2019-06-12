using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2DChart.Domain.Function.Commands;
using _2DChart.Domain.Function.Queries;

namespace _2DChart.Controllers
{

    public class FunctionController : BaseController
    {
        [HttpGet("{id}/evaluate")]
        [ProducesResponseType(typeof(List<Double>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> EvaluateValues(Guid id)
        {
            var result = await Mediator.Send(new EvaluateFunctionValuesQuery { FunctionId = id });
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateFunction([FromBody] CreateFunctionCommand request)
        {
            var result = await Mediator.Send(request);
            return result == null ? (ActionResult)BadRequest() : Ok(result);
        }
    }
}