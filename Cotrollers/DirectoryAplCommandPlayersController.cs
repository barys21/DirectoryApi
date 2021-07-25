using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DirectoryApi.Models;

namespace DirectoryApi.Cotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryAplCommandPlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DirectoryAplCommandPlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DirectoryAplCommandPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectoryAplCommandPlayer>>> GetDirectoryAplCommandPlayers()
        {
            return await _context.DirectoryAplCommandPlayers.ToListAsync();
        }

        // GET: api/DirectoryAplCommandPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectoryAplCommandPlayer>> GetDirectoryAplCommandPlayer(int id)
        {
            var directoryAplCommandPlayer = await _context.DirectoryAplCommandPlayers.FindAsync(id);

            if (directoryAplCommandPlayer == null)
            {
                return NotFound();
            }

            return directoryAplCommandPlayer;
        }

        // PUT: api/DirectoryAplCommandPlayers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectoryAplCommandPlayer(int id, DirectoryAplCommandPlayer directoryAplCommandPlayer)
        {
            if (id != directoryAplCommandPlayer.Id)
            {
                return BadRequest();
            }

            _context.Entry(directoryAplCommandPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryAplCommandPlayerExists(id))
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

        // POST: api/DirectoryAplCommandPlayers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DirectoryAplCommandPlayer>> PostDirectoryAplCommandPlayer(DirectoryAplCommandPlayer directoryAplCommandPlayer)
        {
            _context.DirectoryAplCommandPlayers.Add(directoryAplCommandPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectoryAplCommandPlayer", new { id = directoryAplCommandPlayer.Id }, directoryAplCommandPlayer);
        }

        // DELETE: api/DirectoryAplCommandPlayers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DirectoryAplCommandPlayer>> DeleteDirectoryAplCommandPlayer(int id)
        {
            var directoryAplCommandPlayer = await _context.DirectoryAplCommandPlayers.FindAsync(id);
            if (directoryAplCommandPlayer == null)
            {
                return NotFound();
            }

            _context.DirectoryAplCommandPlayers.Remove(directoryAplCommandPlayer);
            await _context.SaveChangesAsync();

            return directoryAplCommandPlayer;
        }

        private bool DirectoryAplCommandPlayerExists(int id)
        {
            return _context.DirectoryAplCommandPlayers.Any(e => e.Id == id);
        }
    }
}
