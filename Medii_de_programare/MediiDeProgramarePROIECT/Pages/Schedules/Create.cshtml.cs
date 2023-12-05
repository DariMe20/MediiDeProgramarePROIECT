using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Schedules
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
            return Page();
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Schedule.Add(Schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
