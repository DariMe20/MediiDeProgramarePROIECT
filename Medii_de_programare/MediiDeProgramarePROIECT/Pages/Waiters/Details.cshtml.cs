using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Waiters
{
    public class DetailsModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public DetailsModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

      public Waiter Waiter { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Waiter == null)
            {
                return NotFound();
            }

            var waiter = await _context.Waiter.FirstOrDefaultAsync(m => m.ID == id);
            if (waiter == null)
            {
                return NotFound();
            }
            else 
            {
                Waiter = waiter;
            }
            return Page();
        }
    }
}
