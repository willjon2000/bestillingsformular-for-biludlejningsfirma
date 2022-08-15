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
    public class BookingsVehiclesController : Controller
    {
        private readonly h3_biludlejningContext _context;

        public BookingsVehiclesController(h3_biludlejningContext context)
        {
            _context = context;
        }

        // GET: BookingsVehicles
        public async Task<IActionResult> Index()
        {
              return _context.BookingsVehicles != null ? 
                          View(await _context.BookingsVehicles.ToListAsync()) :
                          Problem("Entity set 'h3_biludlejningContext.BookingsVehicles'  is null.");
        }

        // GET: BookingsVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookingsVehicles == null)
            {
                return NotFound();
            }

            var bookingsVehicle = await _context.BookingsVehicles
                .FirstOrDefaultAsync(m => m.BookingVehicleId == id);
            if (bookingsVehicle == null)
            {
                return NotFound();
            }

            return View(bookingsVehicle);
        }

        // GET: BookingsVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingsVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingVehicleId,BookingVehicle,BookingVehiclePrice")] BookingsVehicle bookingsVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingsVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingsVehicle);
        }

        // GET: BookingsVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookingsVehicles == null)
            {
                return NotFound();
            }

            var bookingsVehicle = await _context.BookingsVehicles.FindAsync(id);
            if (bookingsVehicle == null)
            {
                return NotFound();
            }
            return View(bookingsVehicle);
        }

        // POST: BookingsVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingVehicleId,BookingVehicle,BookingVehiclePrice")] BookingsVehicle bookingsVehicle)
        {
            if (id != bookingsVehicle.BookingVehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingsVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsVehicleExists(bookingsVehicle.BookingVehicleId))
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
            return View(bookingsVehicle);
        }

        // GET: BookingsVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookingsVehicles == null)
            {
                return NotFound();
            }

            var bookingsVehicle = await _context.BookingsVehicles
                .FirstOrDefaultAsync(m => m.BookingVehicleId == id);
            if (bookingsVehicle == null)
            {
                return NotFound();
            }

            return View(bookingsVehicle);
        }

        // POST: BookingsVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookingsVehicles == null)
            {
                return Problem("Entity set 'h3_biludlejningContext.BookingsVehicles'  is null.");
            }
            var bookingsVehicle = await _context.BookingsVehicles.FindAsync(id);
            if (bookingsVehicle != null)
            {
                _context.BookingsVehicles.Remove(bookingsVehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsVehicleExists(int id)
        {
          return (_context.BookingsVehicles?.Any(e => e.BookingVehicleId == id)).GetValueOrDefault();
        }
    }
}
