using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2DChart.Domain.Charts;

namespace _2DChart.Controllers
{

    public class ChartController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ChartDto),200)]
        public async Task<ActionResult> GetMockChart()
        {
            var result = await Mediator.Send(new GetChartQuery());
            return Ok(result);
        }
    }
}