using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Models;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolePointController : ControllerBase
    {
        private readonly AppDb _dbContext;

        public HolePointController(AppDb appDb)
        {
            _dbContext = appDb;
        }

        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<HolePoint>>> GetAll()
        {
            return await _dbContext.HolePoints.ToListAsync();
        }

        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<HolePoint>> Get(int id)
        {
            return await _dbContext.HolePoints.FindAsync(id) is HolePoint point
                ? Ok(point) : NotFound();
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Post(HolePoint point)
        {
            if (await _dbContext.Holes.FindAsync(point.HoleId) is null)
                return BadRequest();

            _dbContext.HolePoints.Add(point);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = point.Id }, point);
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, HolePoint point)
        {
            if (point.Id != id)
                return BadRequest();

            var existPoint = await _dbContext.HolePoints.FindAsync(id);

            if (existPoint is null) return NotFound();

            existPoint.X = point.X;
            existPoint.Y = point.Y;
            existPoint.Z = point.Z;
            existPoint.HoleId = point.HoleId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _dbContext.HolePoints.FindAsync(id) is HolePoint point)
            {
                _dbContext.HolePoints.Remove(point);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();
        }
    }
}
