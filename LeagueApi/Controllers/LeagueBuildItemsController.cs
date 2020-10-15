using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeagueApi.Models;

namespace LeagueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueBuildItemsController : ControllerBase
    {
        private readonly Model _context;

        public LeagueBuildItemsController(Model context)
        {
            _context = context;
        }

        // GET: api/leagueBuildItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildItem>>> GetLeagueBuildItem()
        {
            return Ok(await _context.BuildItems.ToListAsync());

        }

        // GET: api/leagueBuildItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildItem>> GetLeagueBuildItem(long id)
        {
            var leagueBuildItem = await _context.BuildItems.FindAsync(id);

            if (leagueBuildItem == null)
            {
                return NotFound();
            }

            return leagueBuildItem;
        }

        // PUT: api/LeagueBuildItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeagueBuildItem(int id, BuildItem leagueBuildItem)
        {
            if (id != leagueBuildItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(leagueBuildItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueBuildItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/leagueBuildItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BuildItem>> PostLeagueBuildItem(BuildItem leagueBuildItem)
        {
                 _context.BuildItems.Add(leagueBuildItem);
                 await _context.SaveChangesAsync();
                return leagueBuildItem;
        }
       
        // DELETE: api/leagueBuildItems/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<BuildItem>> DeleteLeagueBuildItem(int Id)
        {
            var leagueBuildItem = await _context.BuildItems.FirstOrDefaultAsync(e => e.Id == Id);
            if (leagueBuildItem == null)
            {
                return NotFound();
            }

            _context.BuildItems.Remove(leagueBuildItem);
            await _context.SaveChangesAsync();

            return leagueBuildItem;
        }

        private bool LeagueBuildItemExists(long id)
        {
            return _context.BuildItems.Any(e => e.Id == id);
        }

    }

}
