using Microsoft.AspNetCore.Mvc;
using ApiProjekt.Data;
using ApiProjekt.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace ApiProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProstyModelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProstyModelController(ApplicationDbContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public IActionResult Get()
        {
            var models = _context.ProstyModels.ToList();
            return Ok(models);
        }

        [HttpPost]
        // [Authorize]
        public IActionResult Post([FromBody] ProstyModel model)
        {
            if (model == null)
            {
                return BadRequest("Model cannot be null");
            }

            _context.ProstyModels.Add(model);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }
    }
}