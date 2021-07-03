using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController: ControllerBase
    {
        [HttpGet]
        //[Route("api/tickets")]
        public IActionResult Get()
        {
            return Ok("Reading all the tickets");
        }
        //[HttpGet]
        //[Route("api/tickets/{id}")]
        //[Route("{id}")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading a ticket #{id}");
        }
        [HttpPost]
        //[Route("api/tickets")]
        public IActionResult Create()
        {
            return Ok($"Creating a new ticket");
        }
        //[HttpPut]
        //[Route("api/tickets/{id}")]
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok($"Updating a ticket #{id}");
        }
        //[HttpDelete]
        //[Route("api/tickets/{id}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting a ticket #{id}");
        }
    }
}