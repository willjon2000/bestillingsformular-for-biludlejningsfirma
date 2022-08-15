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
    public class BookingsContactsController : Controller
    {
        private readonly h3_biludlejningContext _context;

        public BookingsContactsController(h3_biludlejningContext context)
        {
            _context = context;
        }

        // GET: BookingsContacts
        public async Task<IActionResult> Index()
        {
              return _context.BookingsContacts != null ? 
                          View(await _context.BookingsContacts.ToListAsync()) :
                          Problem("Entity set 'h3_biludlejningContext.BookingsContacts'  is null.");
        }

        // GET: BookingsContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookingsContacts == null)
            {
                return NotFound();
            }

            var bookingsContact = await _context.BookingsContacts
                .FirstOrDefaultAsync(m => m.BookingContactId == id);
            if (bookingsContact == null)
            {
                return NotFound();
            }

            return View(bookingsContact);
        }

        // GET: BookingsContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingsContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingContactId,BookingContactFullname,BookingContactEmail,BookingContactPhone")] BookingsContact bookingsContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingsContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingsContact);
        }

        // GET: BookingsContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookingsContacts == null)
            {
                return NotFound();
            }

            var bookingsContact = await _context.BookingsContacts.FindAsync(id);
            if (bookingsContact == null)
            {
                return NotFound();
            }
            return View(bookingsContact);
        }

        // POST: BookingsContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingContactId,BookingContactFullname,BookingContactEmail,BookingContactPhone")] BookingsContact bookingsContact)
        {
            if (id != bookingsContact.BookingContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingsContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsContactExists(bookingsContact.BookingContactId))
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
            return View(bookingsContact);
        }

        // GET: BookingsContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookingsContacts == null)
            {
                return NotFound();
            }

            var bookingsContact = await _context.BookingsContacts
                .FirstOrDefaultAsync(m => m.BookingContactId == id);
            if (bookingsContact == null)
            {
                return NotFound();
            }

            return View(bookingsContact);
        }

        // POST: BookingsContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookingsContacts == null)
            {
                return Problem("Entity set 'h3_biludlejningContext.BookingsContacts'  is null.");
            }
            var bookingsContact = await _context.BookingsContacts.FindAsync(id);
            if (bookingsContact != null)
            {
                _context.BookingsContacts.Remove(bookingsContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsContactExists(int id)
        {
          return (_context.BookingsContacts?.Any(e => e.BookingContactId == id)).GetValueOrDefault();
        }
    }
}
