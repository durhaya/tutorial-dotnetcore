using Microsoft.AspNetCore.Mvc;
using Project.EF;
using System.Linq;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController: ControllerBase
    {
        private readonly BugsContext db;

        public ProjectsController(BugsContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok("Reading all the projects");
            return Ok(db.Projects.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return Ok($"Reading a project #{id}");
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        ///// <summary>
        ///// api/projects/{pId}/tickets?tid={tid}
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("/api/projects/{pid}/tickets")]
        //public IActionResult GetProjectTicket([FromQuery]Ticket ticket)
        //{
        //    if (ticket.TicketId == 0)
        //    {
        //        return Ok($"Reading all tickets from project #{ticket.ProjectId}");
        //    }
        //    else { 
        //        return Ok($"Reading project #{ticket.ProjectId}, ticket #{ticket.TicketId}, ticket desc {ticket.Description}");
        //    }
        //}

        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTickets(int pId)
        {
            var tickets = db.Tickets.Where(t => t.ProjectId == pId).ToList();
            if (tickets == null || !tickets.Any())
            {
                return NotFound();
            }
            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Core.Models.Project project)
        {
            //return Ok($"Creating a new project");
            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById),
                    new { id = project.ProjectId },
                    project
                );
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Core.Models.Project project)
        {
            //return Ok($"Updating a project #{id}");
            if (id != project.ProjectId) return BadRequest();

            db.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.Projects.Find(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return Ok($"Deleting a project #{id}");
            var project = db.Projects.Find(id);
            if (project == null) return NotFound();
            db.Projects.Remove(project);
            db.SaveChanges();
            return Ok(project);
        }
    }
}