using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Models;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrillBlockController : ControllerBase
    {
        private readonly AppDb _dbContext;

        public DrillBlockController(AppDb appDb)
        {
            _dbContext = appDb;
        }

        // GET all action
        [HttpGet]
        public async Task<ActionResult<List<DrillBlock>>> GetAll()
        {
            return await _dbContext.DrillBlocks.ToListAsync();
        }

        // GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<DrillBlock>> Get(int id)
        {
            return await _dbContext.DrillBlocks.FindAsync(id) is DrillBlock block
                ? Ok(block) : NotFound();
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Post(DrillBlock block)
        {
            _dbContext.DrillBlocks.Add(block);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = block.Id}, block );
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DrillBlock block)
        {
            if (block.Id != id)
                return BadRequest();

            var existBlock = await _dbContext.DrillBlocks.FindAsync(id);

            if (existBlock is null) return NotFound();

            existBlock.Name = block.Name;
            existBlock.UpdateDate = block.UpdateDate;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _dbContext.DrillBlocks.FindAsync(id) is DrillBlock drillBlock)
            {
                _dbContext.DrillBlocks.Remove(drillBlock);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();
        }

    }
}
