using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Tables
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
        ViewData["WaiterID"] = new SelectList(_context.Set<Waiter>(), "ID", "Name");
        ViewData["ZoneID"] = new SelectList(_context.Set<Zone>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Table Table { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Table == null || Table == null)
            {
                return Page();
            }

            _context.Table.Add(Table);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
