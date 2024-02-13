using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Models;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrillBlockPointController : ControllerBase
    {
        private readonly AppDb _dbContext;

        public DrillBlockPointController(AppDb appDb)
        {
            _dbContext = appDb;
        }

        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<DrillBlockPoint>>> GetAll()
        {
            return await _dbContext.DrillBlockPoints.ToListAsync();
        }

        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<DrillBlockPoint>> Get(int id)
        {
            return await _dbContext.DrillBlockPoints.FindAsync(id) is DrillBlockPoint point
                ? Ok(point) : NotFound();
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Post(DrillBlockPoint point)
        {
            if (await _dbContext.DrillBlocks.FindAsync(point.DrillBlockId) is null)
                return BadRequest();

            _dbContext.DrillBlockPoints.Add(point);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = point.Id }, point);
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DrillBlockPoint point)
        {
            if (point.Id != id)
                return BadRequest();

            var existPoint = await _dbContext.DrillBlockPoints.FindAsync(id);

            if (existPoint is null) return NotFound();

            existPoint.Sequence = point.Sequence;
            existPoint.X = point.X;
            existPoint.Y = point.Y;
            existPoint.Z = point.Z;
            existPoint.DrillBlockId = point.DrillBlockId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _dbContext.DrillBlockPoints.FindAsync(id) is DrillBlockPoint point)
            {
                _dbContext.DrillBlockPoints.Remove(point);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();
        }
    }
}
