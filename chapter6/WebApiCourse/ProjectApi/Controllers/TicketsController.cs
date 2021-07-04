using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Project.EF;
using ProjectApi.Filters;
using System;
using System.Linq;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Version1DiscontinueResourceFilter]
    public class TicketsController: ControllerBase
    {
        private readonly BugsContext db;

        public TicketsController(BugsContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok("Reading all the tickets");
            return Ok(db.Tickets.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return Ok($"Reading a ticket #{id}");
            var ticket = db.Tickets.Find(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
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
            //return Ok(ticket);
            db.Tickets.Add(ticket);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById),
                    new { id = ticket.TicketId },
                    ticket
                );
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();

            db.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.Tickets.Find(id) == null) return NotFound();
                throw;
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return Ok($"Deleting a ticket #{id}");
            var ticket = db.Tickets.Find(id);
            if (ticket == null) return NotFound();
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return Ok(ticket);
        }
    }
}