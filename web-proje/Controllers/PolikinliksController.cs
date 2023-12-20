using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_proje.Models;

namespace web_proje.Controllers
{
    public class PolikinliksController : Controller
    {
        private readonly HastaneContext _context;

        public PolikinliksController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Polikinliks
        public async Task<IActionResult> Index()
        {
            var hastaneContext = _context.Polikinlikler.Include(p => p.Hastane);
            return View(await hastaneContext.ToListAsync());
        }

        // GET: Polikinliks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Polikinlikler == null)
            {
                return NotFound();
            }

            var polikinlik = await _context.Polikinlikler
                .Include(p => p.Hastane)
                .FirstOrDefaultAsync(m => m.PolikinlikId == id);
            if (polikinlik == null)
            {
                return NotFound();
            }

            return View(polikinlik);
        }

        // GET: Polikinliks/Create
        public IActionResult Create()
        {
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId");
            return View();
        }

        // POST: Polikinliks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PolikinlikId,HastaneId")] Polikinlik polikinlik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(polikinlik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId", polikinlik.HastaneId);
            return View(polikinlik);
        }

        // GET: Polikinliks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Polikinlikler == null)
            {
                return NotFound();
            }

            var polikinlik = await _context.Polikinlikler.FindAsync(id);
            if (polikinlik == null)
            {
                return NotFound();
            }
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId", polikinlik.HastaneId);
            return View(polikinlik);
        }

        // POST: Polikinliks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PolikinlikId,HastaneId")] Polikinlik polikinlik)
        {
            if (id != polikinlik.PolikinlikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(polikinlik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolikinlikExists(polikinlik.PolikinlikId))
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
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId", polikinlik.HastaneId);
            return View(polikinlik);
        }

        // GET: Polikinliks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Polikinlikler == null)
            {
                return NotFound();
            }

            var polikinlik = await _context.Polikinlikler
                .Include(p => p.Hastane)
                .FirstOrDefaultAsync(m => m.PolikinlikId == id);
            if (polikinlik == null)
            {
                return NotFound();
            }

            return View(polikinlik);
        }

        // POST: Polikinliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Polikinlikler == null)
            {
                return Problem("Entity set 'HastaneContext.Polikinlikler'  is null.");
            }
            var polikinlik = await _context.Polikinlikler.FindAsync(id);
            if (polikinlik != null)
            {
                _context.Polikinlikler.Remove(polikinlik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolikinlikExists(int id)
        {
          return (_context.Polikinlikler?.Any(e => e.PolikinlikId == id)).GetValueOrDefault();
        }
    }
}
