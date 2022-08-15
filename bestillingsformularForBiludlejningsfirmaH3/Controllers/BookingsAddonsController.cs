using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bestillingsformularForBiludlejningsfirmaH3.Entities;

namespace bestillingsformularForBiludlejningsfirmaH3.Controllers
{
    public class BookingsAddonsController : Controller
    {
        private readonly h3_biludlejningContext _context;

        public BookingsAddonsController(h3_biludlejningContext context)
        {
            _context = context;
        }

        // GET: BookingsAddons
        public async Task<IActionResult> Index()
        {
              return _context.BookingsAddons != null ? 
                          View(await _context.BookingsAddons.ToListAsync()) :
                          Problem("Entity set 'h3_biludlejningContext.BookingsAddons'  is null.");
        }

        // GET: BookingsAddons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookingsAddons == null)
            {
                return NotFound();
            }

            var bookingsAddon = await _context.BookingsAddons
                .FirstOrDefaultAsync(m => m.BookingAddonId == id);
            if (bookingsAddon == null)
            {
                return NotFound();
            }

            return View(bookingsAddon);
        }

        // GET: BookingsAddons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingsAddons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingAddonId,BookingAddon,BookingAddonPrice")] BookingsAddon bookingsAddon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingsAddon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingsAddon);
        }

        // GET: BookingsAddons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookingsAddons == null)
            {
                return NotFound();
            }

            var bookingsAddon = await _context.BookingsAddons.FindAsync(id);
            if (bookingsAddon == null)
            {
                return NotFound();
            }
            return View(bookingsAddon);
        }

        // POST: BookingsAddons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingAddonId,BookingAddon,BookingAddonPrice")] BookingsAddon bookingsAddon)
        {
            if (id != bookingsAddon.BookingAddonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingsAddon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsAddonExists(bookingsAddon.BookingAddonId))
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
            return View(bookingsAddon);
        }

        // GET: BookingsAddons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookingsAddons == null)
            {
                return NotFound();
            }

            var bookingsAddon = await _context.BookingsAddons
                .FirstOrDefaultAsync(m => m.BookingAddonId == id);
            if (bookingsAddon == null)
            {
                return NotFound();
            }

            return View(bookingsAddon);
        }

        // POST: BookingsAddons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookingsAddons == null)
            {
                return Problem("Entity set 'h3_biludlejningContext.BookingsAddons'  is null.");
            }
            var bookingsAddon = await _context.BookingsAddons.FindAsync(id);
            if (bookingsAddon != null)
            {
                _context.BookingsAddons.Remove(bookingsAddon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsAddonExists(int id)
        {
          return (_context.BookingsAddons?.Any(e => e.BookingAddonId == id)).GetValueOrDefault();
        }
    }
}
