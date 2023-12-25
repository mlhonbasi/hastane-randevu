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
    public class RandevuController : Controller
    {
        private readonly HastaneContext _context;

        public RandevuController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Randevus
        public async Task<IActionResult> Index()
        {
            var hastaneContext = _context.Randevular.Include(r => r.Doktor).Include(r => r.Hastane).Include(r => r.Kullanici).Include(r => r.Polikinlik);
            return View(await hastaneContext.ToListAsync());
        }

        // GET: Randevus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Hastane)
                .Include(r => r.Kullanici)
                .Include(r => r.Polikinlik)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: Randevus/Create
        public IActionResult Create()
        {
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId");
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId");
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi");
            ViewData["PolikinlikId"] = new SelectList(_context.Polikinlikler, "PolikinlikId", "PolikinlikId");
            return View();
        }

        // POST: Randevus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RandevuId,HastaneId,PolikinlikId,RandevuTarihi,DoktorId,KullaniciId")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId", randevu.DoktorId);
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId", randevu.HastaneId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", randevu.KullaniciId);
            ViewData["PolikinlikId"] = new SelectList(_context.Polikinlikler, "PolikinlikId", "PolikinlikId", randevu.PolikinlikId);
            return View(randevu);
        }

        // GET: Randevus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId", randevu.DoktorId);
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId", randevu.HastaneId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", randevu.KullaniciId);
            ViewData["PolikinlikId"] = new SelectList(_context.Polikinlikler, "PolikinlikId", "PolikinlikId", randevu.PolikinlikId);
            return View(randevu);
        }

        // POST: Randevus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RandevuId,HastaneId,PolikinlikId,RandevuTarihi,DoktorId,KullaniciId")] Randevu randevu)
        {
            if (id != randevu.RandevuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.RandevuId))
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
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "DoktorId", "DoktorId", randevu.DoktorId);
            ViewData["HastaneId"] = new SelectList(_context.Hastaneler, "HastaneId", "HastaneId", randevu.HastaneId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", randevu.KullaniciId);
            ViewData["PolikinlikId"] = new SelectList(_context.Polikinlikler, "PolikinlikId", "PolikinlikId", randevu.PolikinlikId);
            return View(randevu);
        }

        // GET: Randevus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevular
                .Include(r => r.Doktor)
                .Include(r => r.Hastane)
                .Include(r => r.Kullanici)
                .Include(r => r.Polikinlik)
                .FirstOrDefaultAsync(m => m.RandevuId == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randevular == null)
            {
                return Problem("Entity set 'HastaneContext.Randevular'  is null.");
            }
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
          return (_context.Randevular?.Any(e => e.RandevuId == id)).GetValueOrDefault();
        }
    }
}
