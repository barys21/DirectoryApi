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
    public class DirectoryAPLsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DirectoryAPLsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DirectoryAPLs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectoryAPL>>> GetDirectoryAPLs()
        {
            return await _context.DirectoryAPLs.ToListAsync();
        }

        // GET: api/DirectoryAPLs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectoryAPL>> GetDirectoryAPL(int id)
        {
            var directoryAPL = await _context.DirectoryAPLs.FindAsync(id);

            if (directoryAPL == null)
            {
                return NotFound();
            }

            return directoryAPL;
        }

        // PUT: api/DirectoryAPLs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectoryAPL(int id, DirectoryAPL directoryAPL)
        {
            if (id != directoryAPL.Id)
            {
                return BadRequest();
            }

            _context.Entry(directoryAPL).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryAPLExists(id))
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

        // POST: api/DirectoryAPLs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DirectoryAPL>> PostDirectoryAPL(DirectoryAPL directoryAPL)
        {
            _context.DirectoryAPLs.Add(directoryAPL);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectoryAPL", new { id = directoryAPL.Id }, directoryAPL);
        }

        // DELETE: api/DirectoryAPLs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DirectoryAPL>> DeleteDirectoryAPL(int id)
        {
            var directoryAPL = await _context.DirectoryAPLs.FindAsync(id);
            if (directoryAPL == null)
            {
                return NotFound();
            }

            _context.DirectoryAPLs.Remove(directoryAPL);
            await _context.SaveChangesAsync();

            return directoryAPL;
        }

        private bool DirectoryAPLExists(int id)
        {
            return _context.DirectoryAPLs.Any(e => e.Id == id);
        }
    }
}
