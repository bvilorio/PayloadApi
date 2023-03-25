using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayloadApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayloadApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private readonly IRobotManager _robotManager;
        public RobotsController(IRobotManager robotManager)
        {
            _robotManager = robotManager;
        }

        // GET api/<RobotsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        

        // POST api/<RobotsController>/closest
        [Route("closest")]
        [HttpPost]
        public PayloadResponse Post([FromBody] Payload payload)
        {                   
            return _robotManager.GetNearestRobot(payload);
        }

        // PUT api/<RobotsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RobotsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
