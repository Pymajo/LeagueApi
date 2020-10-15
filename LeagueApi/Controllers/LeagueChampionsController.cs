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
    public class LeagueChampionsController : ControllerBase
    {
        private readonly Model _context;

        public LeagueChampionsController(Model context)
        {
            _context = context;
        }

        // GET: api/LeagueChampions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Champion>>> GetLeagueChampion()
        {
            return Ok(await _context.Champions.ToListAsync());

        }

        // GET: api/LeagueChampions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Champion>> GetLeagueChampion(long id)
        {
            var leagueChampion = await _context.Champions.FindAsync(id);

            if (leagueChampion == null)
            {
                return NotFound();
            }

            return leagueChampion;
        }

        // PUT: api/LeagueChampions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeagueChampion(int id, Champion leagueChampion)
        {
            if (id != leagueChampion.Id)
            {
                return BadRequest();
            }

            _context.Entry(leagueChampion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueChampionExists(id))
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

        // POST: api/LeagueChampions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostLeagueChampion(Champion[] leagueChampions)
        {
            foreach (Champion leagueChampion in leagueChampions)
            {
                 _context.Champions.Add(leagueChampion);
                 await _context.SaveChangesAsync();
            }
            return Ok();

        }


        // DELETE: api/LeagueChampions/5
        [HttpDelete("{championId}")]
        public async Task<ActionResult<Champion>> DeleteLeagueChampion(int championId)
        {
            var leagueChampion = await _context.Champions.FirstOrDefaultAsync(e => e.ChampionId == championId);
            if (leagueChampion == null)
            {
                return NotFound();
            }

            _context.Champions.Remove(leagueChampion);
            await _context.SaveChangesAsync();

            return leagueChampion;
        }

        private bool LeagueChampionExists(long id)
        {
            return _context.Champions.Any(e => e.Id == id);
        }

    }

}
