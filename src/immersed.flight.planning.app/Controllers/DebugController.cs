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

            foreach (var a in this.Request.Headers)
            {
                sb.AppendLine($"{a.Key}:{a.Value}");
            }

            return new OkObjectResult(sb);
        }
    }
}
