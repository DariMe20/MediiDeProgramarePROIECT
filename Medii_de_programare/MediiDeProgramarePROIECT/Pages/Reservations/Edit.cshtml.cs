using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly MediiDeProgramarePROIECTContext _context;

        public EditModel(MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableList = _context.Table
              .Include(t => t.Waiter)
              .Include(t => t.Zone)
              .Include(t => t.BookingSchedules)
                  .ThenInclude(bs => bs.Schedule)
              .Select(x => new
              {
                  x.ID,
                  Details = $"Masa {x.ID}, Locuri: {x.Seats}, Zona: {x.Zone.Name}, Zile disponibile: " +
                            string.Join(", ", x.BookingSchedules.Select(bs => $"{bs.Schedule.ScheduleName}"))
              }).ToList();

            Reservation = await _context.Reservation
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Reservation == null)
            {
                return NotFound();
            }

            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "Email", Reservation.ClientID);
            ViewData["TableID"] = new SelectList(_context.Table, "ID", "ID", Reservation.TableID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID", Reservation.ClientID);
                ViewData["TableID"] = new SelectList(_context.Table, "ID","ID", Reservation.TableID);
                return Page();
            }

            _context.Attach(Reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(Reservation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ID == id);
        }
    }
}
