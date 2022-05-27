using AspNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCController : ControllerBase
    {

        private readonly PCService pc;

        public PCController(PCService pc)
        {
            this.pc = pc;  
        }

        [HttpGet("getPC")]
        public async Task<List<PC>> Get()
        {
            var data = await pc.Get();
            return data;
        }

        [HttpGet("getPCById")]
        public async Task<PC> Get(string id)
        {
            var data = await pc.Get(id);
            return data;
        }

        [HttpPost("createPC")]
        public async Task<ActionResult> CreatePC([FromBody] PC newPC)
        {
            await pc.Create(newPC);
            return Ok();
        }

        [HttpPut("updatePC")]
        public async Task UpdatePC(string id, PC updatePC)
        {
           await pc.Update(id, updatePC);
        }

        [HttpDelete("deletePC")]
        public async Task<ActionResult> DeletePC(string id)
        {
            await pc.Remove(id);
            return Ok();
        }
    }
}
