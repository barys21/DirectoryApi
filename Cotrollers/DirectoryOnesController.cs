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
    public class DirectoryOnesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DirectoryOnesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DirectoryOnes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectoryOne>>> GetDirectoryOnes()
        {
            return await _context.DirectoryOnes.ToListAsync();
        }

        // GET: api/DirectoryOnes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectoryOne>> GetDirectoryOne(int id)
        {
            var directoryOne = await _context.DirectoryOnes.FindAsync(id);

            if (directoryOne == null)
            {
                return NotFound();
            }

            return directoryOne;
        }

        // PUT: api/DirectoryOnes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectoryOne(int id, DirectoryOne directoryOne)
        {
            if (id != directoryOne.Id)
            {
                return BadRequest();
            }

            _context.Entry(directoryOne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryOneExists(id))
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

        // POST: api/DirectoryOnes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DirectoryOne>> PostDirectoryOne(DirectoryOne directoryOne)
        {
            _context.DirectoryOnes.Add(directoryOne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectoryOne", new { id = directoryOne.Id }, directoryOne);
        }

        // DELETE: api/DirectoryOnes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DirectoryOne>> DeleteDirectoryOne(int id)
        {
            var directoryOne = await _context.DirectoryOnes.FindAsync(id);
            if (directoryOne == null)
            {
                return NotFound();
            }

            _context.DirectoryOnes.Remove(directoryOne);
            await _context.SaveChangesAsync();

            return directoryOne;
        }

        private bool DirectoryOneExists(int id)
        {
            return _context.DirectoryOnes.Any(e => e.Id == id);
        }
    }
}
