using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Schedules
{
    public class DetailsModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public DetailsModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

      public Schedule Schedule { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FirstOrDefaultAsync(m => m.ID == id);
            if (schedule == null)
            {
                return NotFound();
            }
            else 
            {
                Schedule = schedule;
            }
            return Page();
        }
    }
}
