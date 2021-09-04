using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace immersed.flight.planning.app.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FlightPlanController : ControllerBase
    {
        [HttpGet]
        [Route("~/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFlightPlans()
        {
            return Ok();
        }

        [HttpGet]
        [Route("~/{flightPlanId}")]
        public IActionResult GetFlightPlan(Guid flightPlanId)
        {
            return Ok();
        }
    }
}
