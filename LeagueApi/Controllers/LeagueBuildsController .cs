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
    public class LeagueBuildsController : ControllerBase
    {
        private readonly Model _context;

        public LeagueBuildsController(Model context)
        {
            _context = context;
        }

        // GET: api/leagueBuilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Build>>> GetLeagueBuild()
        {
            return Ok(await _context.Builds.ToListAsync());

        }

        // GET: api/leagueBuilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Build>> GetLeagueBuild(long id)
        {
            var leagueBuild = await _context.Builds.FindAsync(id);

            if (leagueBuild == null)
            {
                return NotFound();
            }

            return leagueBuild;
        }

        // PUT: api/LeagueBuilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeagueBuild(int id, Build leagueBuild)
        {
            if (id != leagueBuild.Id)
            {
                return BadRequest();
            }

            _context.Entry(leagueBuild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueBuildExists(id))
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

        // POST: api/leagueBuilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Build>> PostLeagueBuild(Build leagueBuild)
        {
            _context.Builds.Add(leagueBuild);
            await _context.SaveChangesAsync();
            return leagueBuild;
        }


        // DELETE: api/leagueBuilds/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Build>> DeleteLeagueBuild(int Id)
        {
            var leagueBuild = await _context.Builds.FirstOrDefaultAsync(e => e.Id == Id);
            if (leagueBuild == null)
            {
                return NotFound();
            }

            _context.Builds.Remove(leagueBuild);
            await _context.SaveChangesAsync();

            return leagueBuild;
        }

        private bool LeagueBuildExists(long id)
        {
            return _context.Builds.Any(e => e.Id == id);
        }

    }

}
