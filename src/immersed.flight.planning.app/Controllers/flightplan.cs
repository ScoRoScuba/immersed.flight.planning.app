using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace immersed.flight.planning.app.Controllers
{
    [ApiController]
    public class FlightPlanController : ControllerBase
    {
        private readonly ILogger _logger;

        public FlightPlanController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("~/flightplan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFlightPlans()
        {
            _logger.Information($"{nameof(FlightPlanController)}:{nameof(GetFlightPlans)}");
            return Ok();
        }

        [HttpGet]
        [Route("~/flightplan/{flightPlanId}")]
        public IActionResult GetFlightPlan(Guid flightPlanId)
        {
            _logger.Information($"{nameof(FlightPlanController)}:{nameof(GetFlightPlans)}:{flightPlanId}");
            return Ok();
        }
    }
}
