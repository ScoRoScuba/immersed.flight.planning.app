using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace immersed.flight.planning.app.Controllers
{
    [ApiController]
    public class DebugController : ControllerBase
    {

        [HttpGet]
        [Route("~/debug")]

        public IActionResult Index()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Request.PathBase:{Request.PathBase}");
            sb.AppendLine($"Request.Path:{Request.Path}");

            foreach (var a in Request.Headers)
            {
                sb.AppendLine($"Request:{a.Key}:{a.Value}");
            }

            foreach (var a in Response.Headers)
            {
                sb.AppendLine($"Response:{a.Key}:{a.Value}");
            }

            return new OkObjectResult(sb);
        }
    }
}
