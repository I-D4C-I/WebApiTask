using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Models;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoleController : ControllerBase
    {
        private readonly AppDb _dbContext;

        public HoleController(AppDb appDb)
        {
            _dbContext = appDb;
        }

        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<Hole>>> GetAll()
        {
            return await _dbContext.Holes.ToListAsync();
        }

        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Hole>> Get(int id)
        {
            return await _dbContext.Holes.FindAsync(id) is Hole hole
                ? Ok(hole) : NotFound();
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Post(Hole hole)
        {
            if(await _dbContext.DrillBlocks.FindAsync(hole.DrillBlockId) is null)
                return BadRequest();
            
            _dbContext.Holes.Add(hole);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hole.Id }, hole);
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hole hole)
        {
            if (hole.Id != id)
                return BadRequest();

            var existHole = await _dbContext.Holes.FindAsync(id);

            if (existHole is null) return NotFound();

            existHole.Name = hole.Name;
            existHole.Depth = hole.Depth;
            existHole.DrillBlockId = hole.DrillBlockId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _dbContext.Holes.FindAsync(id) is Hole hole)
            {
                _dbContext.Holes.Remove(hole);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();
        }

    }
}
