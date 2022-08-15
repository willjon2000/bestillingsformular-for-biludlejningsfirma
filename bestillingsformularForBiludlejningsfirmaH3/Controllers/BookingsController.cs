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
    public class BookingsController : Controller
    {
        private readonly h3_biludlejningContext _context;

        public BookingsController(h3_biludlejningContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var h3_biludlejningContext = _context.Bookings.Include(b => b.BookingContact).Include(b => b.BookingVehicle);
            return View(await h3_biludlejningContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.BookingContact)
                .Include(b => b.BookingVehicle)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["BookingContactId"] = new SelectList(_context.BookingsContacts, "BookingContactId", "BookingContactId");
            ViewData["BookingVehicleId"] = new SelectList(_context.BookingsVehicles, "BookingVehicleId", "BookingVehicleId");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,BookingVehicleId,BookingContactId,BookingTimestampEnd,BookingTimestampStart")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingContactId"] = new SelectList(_context.BookingsContacts, "BookingContactId", "BookingContactId", booking.BookingContactId);
            ViewData["BookingVehicleId"] = new SelectList(_context.BookingsVehicles, "BookingVehicleId", "BookingVehicleId", booking.BookingVehicleId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["BookingContactId"] = new SelectList(_context.BookingsContacts, "BookingContactId", "BookingContactId", booking.BookingContactId);
            ViewData["BookingVehicleId"] = new SelectList(_context.BookingsVehicles, "BookingVehicleId", "BookingVehicleId", booking.BookingVehicleId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,BookingVehicleId,BookingContactId,BookingTimestampEnd,BookingTimestampStart")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
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
            ViewData["BookingContactId"] = new SelectList(_context.BookingsContacts, "BookingContactId", "BookingContactId", booking.BookingContactId);
            ViewData["BookingVehicleId"] = new SelectList(_context.BookingsVehicles, "BookingVehicleId", "BookingVehicleId", booking.BookingVehicleId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.BookingContact)
                .Include(b => b.BookingVehicle)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'h3_biludlejningContext.Bookings'  is null.");
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.Bookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
