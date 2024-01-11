using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BungalowProject.Data;

namespace BungalowProject.Controllers
{
    public class BungalowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BungalowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bungalows
        public async Task<IActionResult> Index()
        {
              return _context.Bungalow != null ? 
                          View(await _context.Bungalow.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Bungalow'  is null.");
        }

        // GET: Bungalows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bungalow == null)
            {
                return NotFound();
            }

            var bungalow = await _context.Bungalow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bungalow == null)
            {
                return NotFound();
            }

            return View(bungalow);
        }

        // GET: Bungalows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bungalows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BungalowId,Capacity,IsSmokingAllowed,IsAvalive,AllowsPets,Location,PricePerNight")] Bungalow bungalow)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(bungalow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bungalow);
        }

        // GET: Bungalows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bungalow == null)
            {
                return NotFound();
            }

            var bungalow = await _context.Bungalow.FindAsync(id);
            if (bungalow == null)
            {
                return NotFound();
            }
            return View(bungalow);
        }

        // POST: Bungalows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BungalowId,Capacity,IsSmokingAllowed,IsAvalive,AllowsPets,Location,PricePerNight")] Bungalow bungalow)
        {
            if (id != bungalow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bungalow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BungalowExists(bungalow.Id))
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
            return View(bungalow);
        }

        // GET: Bungalows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bungalow == null)
            {
                return NotFound();
            }

            var bungalow = await _context.Bungalow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bungalow == null)
            {
                return NotFound();
            }

            return View(bungalow);
        }

        // POST: Bungalows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bungalow == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bungalow'  is null.");
            }
            var bungalow = await _context.Bungalow.FindAsync(id);
            if (bungalow != null)
            {
                _context.Bungalow.Remove(bungalow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BungalowExists(int id)
        {
          return (_context.Bungalow?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
