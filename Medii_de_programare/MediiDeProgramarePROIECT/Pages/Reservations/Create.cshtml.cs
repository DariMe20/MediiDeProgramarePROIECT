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

namespace MediiDeProgramarePROIECT.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public CreateModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var tableList = _context.Table
              .Include(b => b.Waiter)
              .Select(x => new
             {
              x.ID,
              Table = x.Seats + " - " + x.Waiter.Name
            });
            ViewData["TableID"] = new SelectList(tableList, "ID", "Table");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
       
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reservation == null || Reservation == null)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
