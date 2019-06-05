using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2DChart.Domain.Function.Commands;

namespace _2DChart.Controllers
{

    public class FunctionController : BaseController
    {
        [HttpGet("{id}/evaluate")]
        [ProducesResponseType(typeof(List<Double>),200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> EvaluateValues(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid),201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> CreateFunction([FromBody] CreateFunctionCommand request)
        {
            return Ok();
        }
    }
}