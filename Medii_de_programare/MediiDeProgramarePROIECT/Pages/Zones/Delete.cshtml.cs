using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Zones
{
    public class DeleteModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public DeleteModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Zone Zone { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zone == null)
            {
                return NotFound();
            }

            var zone = await _context.Zone.FirstOrDefaultAsync(m => m.ID == id);

            if (zone == null)
            {
                return NotFound();
            }
            else 
            {
                Zone = zone;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zone == null)
            {
                return NotFound();
            }
            var zone = await _context.Zone.FindAsync(id);

            if (zone != null)
            {
                Zone = zone;
                _context.Zone.Remove(Zone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
