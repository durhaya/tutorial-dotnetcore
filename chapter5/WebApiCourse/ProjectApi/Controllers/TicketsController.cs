using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Filters;
using System;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Version1DiscontinueResourceFilter]
    public class TicketsController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the tickets");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading a ticket #{id}");
        }
        [Version1DiscontinueResourceFilter]
        [HttpPost]
        //public IActionResult Create([FromQuery] Ticket ticket)
        public IActionResult Create(Ticket ticket)
        {
            //Console.WriteLine($"Model State - {ModelState.IsValid}, title - {ticket.Title}");
            ////Below is not required because of ApiController
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            return Ok(ticket);
        }
        [HttpPost]
        [Route("/api/v2/tickets")]
        public IActionResult CreateV2(Ticket ticket)
        {
            //Console.WriteLine($"Model State - {ModelState.IsValid}, title - {ticket.Title}");
            ////Below is not required because of ApiController
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            return Ok(ticket);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();

            return Ok(ticket);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting a ticket #{id}");
        }
    }
}