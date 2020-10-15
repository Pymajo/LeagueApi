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
    public class LeagueItemsController : ControllerBase
    {
        private readonly Model _context;

        public LeagueItemsController(Model context)
        {
            _context = context;
        }

        // GET: api/LeagueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetLeagueItems()
        {
            return Ok(await _context.Items.ToListAsync());
            
        }

        // GET: api/LeagueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetLeagueItem(long id)
        {
            var leagueItem = await _context.Items.FindAsync(id);

            if (leagueItem == null)
            {
                return NotFound();
            }

            return leagueItem;
        }

        // PUT: api/LeagueItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeagueItem(int id, Item leagueItem)
        {
            if (id != leagueItem.Id) 
            {
                return BadRequest();
            }

            _context.Entry(leagueItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueItemExists(id))
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

        // POST: api/LeagueItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostLeagueItem(ItemDTO[] leagueItems)
        {
             
            foreach (ItemDTO leagueItem in leagueItems)
            {
                Item item=new Item();
                item.Image=leagueItem.Image.Full;
                item.Gold = leagueItem.Gold.Total;
                item.ItemId = leagueItem.ItemId;
                item.Name = leagueItem.Name;
                item.Plaintext = leagueItem.Plaintext;
                item.Description = leagueItem.Description;
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

               
            }
            return Ok();
        }

        // DELETE: api/LeagueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteLeagueItem(long id)
        {
            var leagueItem = await _context.Items.FindAsync(id);
            if (leagueItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(leagueItem);
            await _context.SaveChangesAsync();

            return leagueItem;
        }

        private bool LeagueItemExists(long id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
 
    }

}
