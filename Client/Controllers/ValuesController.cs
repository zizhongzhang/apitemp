using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApiServiceClient _client;
        public ValuesController(ApiServiceClient client)
        {
            _client = client;
        }

        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var sp = new Stopwatch();
            sp.Start();
            var values = await _client.GetValues();
            sp.Stop();
            var newArray = new string[values.Length + 1];
            values.CopyTo(newArray, 0);
            newArray[values.Length] = sp.ElapsedMilliseconds.ToString();
            return string.Join(",", newArray);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
