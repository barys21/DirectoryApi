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
    public class DirectoryTwoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DirectoryTwoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DirectoryTwoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectoryTwo>>> GetDirectoryTwos()
        {
            return await _context.DirectoryTwos.ToListAsync();
        }

        // GET: api/DirectoryTwoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectoryTwo>> GetDirectoryTwo(int id)
        {
            var directoryTwo = await _context.DirectoryTwos.FindAsync(id);

            if (directoryTwo == null)
            {
                return NotFound();
            }

            return directoryTwo;
        }

        // PUT: api/DirectoryTwoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectoryTwo(int id, DirectoryTwo directoryTwo)
        {
            if (id != directoryTwo.Id)
            {
                return BadRequest();
            }

            _context.Entry(directoryTwo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryTwoExists(id))
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

        // POST: api/DirectoryTwoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DirectoryTwo>> PostDirectoryTwo(DirectoryTwo directoryTwo)
        {
            _context.DirectoryTwos.Add(directoryTwo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectoryTwo", new { id = directoryTwo.Id }, directoryTwo);
        }

        // DELETE: api/DirectoryTwoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DirectoryTwo>> DeleteDirectoryTwo(int id)
        {
            var directoryTwo = await _context.DirectoryTwos.FindAsync(id);
            if (directoryTwo == null)
            {
                return NotFound();
            }

            _context.DirectoryTwos.Remove(directoryTwo);
            await _context.SaveChangesAsync();

            return directoryTwo;
        }

        private bool DirectoryTwoExists(int id)
        {
            return _context.DirectoryTwos.Any(e => e.Id == id);
        }
    }
}
