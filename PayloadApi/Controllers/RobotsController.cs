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

        public RobotManager RobotManager { get; set; }
        // GET: api/<RobotsController>
        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://60c8ed887dafc90017ffbd56.mockapi.io/robots");

        //        using (HttpResponseMessage response = await client.GetAsync("robots")) 
        //        {
        //            var responseContent = response.Content.ReadAsStringAsync().Result;
        //            response.EnsureSuccessStatusCode();

        //            return Ok(responseContent);
        //        }
        //    }
        //}

        // GET api/<RobotsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            RobotManager = new RobotManager();
            var desRobots = RobotManager.GetDeserializedRobots();
            return RobotManager.GetRobots();
        }

        // POST api/<RobotsController>/closest
        [Route("closest")]
        [HttpPost]
        public PayloadResponse Post([FromBody] Payload payload)
        {
            RobotManager = new RobotManager();
            var desRobots = RobotManager.GetDeserializedRobots();
            return RobotManager.GetNearestRobot(desRobots, payload);
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
