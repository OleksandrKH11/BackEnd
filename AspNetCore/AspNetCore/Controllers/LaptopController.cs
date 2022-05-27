using AspNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : Controller
    {

        private readonly LaptopService laptop;

        public LaptopController(LaptopService laptop)
        {
            this.laptop = laptop;
        }

        [HttpGet("getLaptop")]
        public async Task<List<Laptop>> GetLaptop()
        {
            var data = await laptop.Get();
            return data;
        }

        [HttpGet("getLaptopById")]
        public async Task<Laptop> GetLaptopById(string id)
        {
            var data = await laptop.Get(id);
            return data;
        }

        [HttpPost("createLaptop")]
        public async Task<ActionResult> CreateLaptop([FromBody] Laptop newLaptop)
        {
            await laptop.Create(newLaptop);
            return Ok();
        }

        [HttpPut("updateLaptop")]
        public async Task UpdateTicket(string id, Laptop updateLaptop)
        {
            await laptop.Update(id, updateLaptop);
        }

        [HttpDelete("deleteLaptop")]
        public async Task<ActionResult> DeleteLaptop(string id)
        {
            await laptop.Remove(id);
            return Ok();
        }
    }
}
