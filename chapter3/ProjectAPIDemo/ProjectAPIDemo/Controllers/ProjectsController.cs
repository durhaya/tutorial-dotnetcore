using Microsoft.AspNetCore.Mvc;

namespace ProjectAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading all the projects");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading a project #{id}");
        }
        [HttpPost]
        public IActionResult Create()
        {
            return Ok($"Creating a new project");
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok($"Updating a project #{id}");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting a project #{id}");
        }
    }
}