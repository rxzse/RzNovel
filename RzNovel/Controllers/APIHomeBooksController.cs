using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RzNovel.Models;

namespace RzNovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIHomeBooksController : ControllerBase
    {
        private readonly RzNovelContext _context;

        public APIHomeBooksController(RzNovelContext context)
        {
            _context = context;
        }

        // GET: api/APIHomeBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeBook>>> GetHomeBooks()
        {
            return await _context.HomeBooks.ToListAsync();
        }

        // GET: api/APIHomeBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeBook>> GetHomeBook(long id)
        {
            var homeBook = await _context.HomeBooks.FindAsync(id);

            if (homeBook == null)
            {
                return NotFound();
            }

            return homeBook;
        }

        // PUT: api/APIHomeBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeBook(long id, HomeBook homeBook)
        {
            if (id != homeBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(homeBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeBookExists(id))
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

        // POST: api/APIHomeBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HomeBook>> PostHomeBook(HomeBook homeBook)
        {
            _context.HomeBooks.Add(homeBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeBook", new { id = homeBook.Id }, homeBook);
        }

        // DELETE: api/APIHomeBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeBook(long id)
        {
            var homeBook = await _context.HomeBooks.FindAsync(id);
            if (homeBook == null)
            {
                return NotFound();
            }

            _context.HomeBooks.Remove(homeBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeBookExists(long id)
        {
            return _context.HomeBooks.Any(e => e.Id == id);
        }
    }
}
