using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public IndexModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }
        
        public IList<Reservation> Reservation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reservation != null)
            {
                Reservation = await _context.Reservation
                    .Include(r => r.Table)
                        .ThenInclude(t => t.Waiter)
                    .Include(r => r.Table)
                        .ThenInclude(t => t.Zone)
                    .Include(r => r.Client)
                    .OrderBy(r => r.ReservationDate) // Sortare mai întâi după dată
                    .ThenBy(r => r.ReservationTime) // Apoi după oră
                    .ToListAsync();
            }
        }

    }
}
