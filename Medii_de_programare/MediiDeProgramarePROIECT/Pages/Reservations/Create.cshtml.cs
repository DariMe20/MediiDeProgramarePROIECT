using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MediiDeProgramarePROIECT.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateModel(MediiDeProgramarePROIECTContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? tableId)
        {
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
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("Utilizatorul nu este logat.");
            }

            ViewData["TableID"] = new SelectList(tableList, "ID", "Details", "ID");
            ViewData["ClientID"] = user.Email;

            // Restabilește TableID în modelul Reservation dacă este specificat
            if (tableId.HasValue)
            {
                Reservation = new Reservation { TableID = tableId };
            }

            // Restabilește datele despre masa dacă există erori și TableID a fost deja selectat
            if (!ModelState.IsValid && Reservation.TableID.HasValue)
            {
                ViewData["TableID"] = new SelectList(tableList, "ID", "Details", Reservation.TableID.Value);
            }
            else
            {
                ViewData["TableID"] = new SelectList(tableList, "ID", "Details");
            }

            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");

            return Page();
        }



        [BindProperty]
        public Reservation Reservation { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
{
            if (!ModelState.IsValid || _context.Reservation == null || Reservation == null)
            {
                return Page(); // Returnează pagina cu datele existente
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("Utilizatorul nu este logat.");
            }
            var table = await _context.Table
            
        .Include(t => t.BookingSchedules)
        .FirstOrDefaultAsync(t => t.ID == Reservation.TableID);

    if (table == null || !IsTableAvailableForReservation(table, Reservation))
    {
        ModelState.AddModelError(string.Empty, "Masa nu este disponibilă pentru data și ora selectate.");
        return Page();
    }
            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();
     

            return RedirectToPage("./Index");
}




        private bool IsTableAvailableForReservation(Table table, Reservation reservation)
        {
            var reservationDate = reservation.ReservationDate.Date;
            var reservationStartTime = reservation.ReservationTime.TimeOfDay;
            var reservationEndTime = reservation.ReservationTime.AddHours(reservation.ReservationDuration).TimeOfDay;

            // 1. Verifică dacă data rezervării este într-un interval permis de 6 zile de la data curentă
            if (reservationDate < DateTime.Now.Date || reservationDate > DateTime.Now.Date.AddDays(6))
            {
                ModelState.AddModelError("Reservation.ReservationDate", "Data rezervării trebuie să fie în următoarele 6 zile.");
                return false;
            }

            foreach (var bookingSchedule in table.BookingSchedules)
            {
                var schedule = _context.Schedule.Find(bookingSchedule.ScheduleID);
                if (schedule != null && schedule.DayOfWeek == reservationDate.DayOfWeek)
                {
                    // 2. Verifică dacă ora de începere plus durata depășește timpul de sfârșit al orarului mesei
                    if (reservationStartTime < schedule.StartTime || reservationEndTime > schedule.EndTime || reservationEndTime < schedule.StartTime)
                    {
                        ModelState.AddModelError("Reservation.ReservationTime", "Intervalul orar selectat depășește orarul disponibil al mesei. -schedule.StartTime -schedule.EndTime");
                        return false;
                    }

                    // 3. Verifică dacă există suprapuneri cu alte rezervări
                    var overlappingReservationExists = _context.Reservation.Any(r =>
                        r.TableID == table.ID &&
                        r.ReservationDate == reservationDate &&
                        (r.ReservationTime.TimeOfDay < reservationEndTime &&
                         r.ReservationTime.AddHours(r.ReservationDuration).TimeOfDay > reservationStartTime));

                    if (overlappingReservationExists)
                    {
                        ModelState.AddModelError("Reservation.ReservationTime", "Există o suprapunere cu o altă rezervare.");
                        return false;
                    }
                }
            }

            return true; // Masa este disponibilă pentru rezervare
        }
    }
}
