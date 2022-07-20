using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RzNovel.Models;

namespace RzNovel.Controllers
{
    public class HomeBooksController : Controller
    {
        private readonly RzNovelContext _context;

        public HomeBooksController(RzNovelContext context)
        {
            _context = context;
        }

        // GET: HomeBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeBooks.ToListAsync());
        }

        // GET: HomeBooks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeBook = await _context.HomeBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeBook == null)
            {
                return NotFound();
            }

            return View(homeBook);
        }

        // GET: HomeBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Sort,BookId,CreateTime,UpdateTime")] HomeBook homeBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeBook);
        }

        // GET: HomeBooks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeBook = await _context.HomeBooks.FindAsync(id);
            if (homeBook == null)
            {
                return NotFound();
            }
            return View(homeBook);
        }

        // POST: HomeBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Type,Sort,BookId,CreateTime,UpdateTime")] HomeBook homeBook)
        {
            if (id != homeBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeBookExists(homeBook.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(homeBook);
        }

        // GET: HomeBooks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeBook = await _context.HomeBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeBook == null)
            {
                return NotFound();
            }

            return View(homeBook);
        }

        // POST: HomeBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var homeBook = await _context.HomeBooks.FindAsync(id);
            _context.HomeBooks.Remove(homeBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeBookExists(long id)
        {
            return _context.HomeBooks.Any(e => e.Id == id);
        }
    }
}
