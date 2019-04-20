using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET api/tasks/1
        [HttpGet("1")]
        public async Task<ActionResult<string[]>> Task1()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return new string[] { "apple", "orange" };
        }

        // GET api/tasks/2
        [HttpGet("2")]
        public async Task<ActionResult<int>> Task2()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return 66;
        }

        // GET api/tasks/3
        [HttpGet("3")]
        public async Task<ActionResult<string>> Task3()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            return "66";
        }

        // GET api/tasks/4
        [HttpGet("4")]
        public IActionResult Task4()
        {
            return new StatusCodeResult(500);
        }
    }
}
