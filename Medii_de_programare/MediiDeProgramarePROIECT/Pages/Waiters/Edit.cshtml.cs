using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Waiters
{
    public class EditModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public EditModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Waiter Waiter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Waiter == null)
            {
                return NotFound();
            }

            var waiter =  await _context.Waiter.FirstOrDefaultAsync(m => m.ID == id);
            if (waiter == null)
            {
                return NotFound();
            }
            Waiter = waiter;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Waiter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaiterExists(Waiter.ID))
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

        private bool WaiterExists(int id)
        {
          return (_context.Waiter?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
