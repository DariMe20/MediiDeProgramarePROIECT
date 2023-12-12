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
using Microsoft.AspNetCore.Authorization;

namespace MediiDeProgramarePROIECT.Pages.Tables
{
    [Authorize(Roles = "Admin")]
    public class EditModel : TableSchedulesPageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public EditModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Table Table { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .Include(b => b.Waiter)
                .Include(b => b.Zone)
                .Include(b => b.BookingSchedules).ThenInclude(b => b.Schedule)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (table == null)
            {
                return NotFound();
            }
            Table = table;
            ViewData["WaiterID"] = new SelectList(_context.Set<Waiter>(), "ID", "Name");
            ViewData["ZoneID"] = new SelectList(_context.Set<Zone>(), "ID", "Name");
            PopulateAssignedScheduleData(_context, Table);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSchedules)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableToUpdate = await _context.Table
                .Include(t => t.Waiter) // Presupunând că există o legătură cu Waiter
                .Include(t => t.Zone)   // Presupunând că există o legătură cu Zone
                .Include(t => t.BookingSchedules)
                .ThenInclude(bs => bs.Schedule)
                .FirstOrDefaultAsync(t => t.ID == id);

            if (tableToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Table>(
                tableToUpdate,
                "Table", // Prefixul pentru form binding
                t => t.Seats, t => t.WaiterID, t => t.ZoneID)) // Adaugă alte proprietăți necesare
            {
                UpdateTableSchedules(_context, selectedSchedules, tableToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Dacă actualizarea nu reușește, repopulează datele pentru view
            UpdateTableSchedules(_context, selectedSchedules, tableToUpdate);
            PopulateAssignedScheduleData(_context, tableToUpdate);
            return Page();
        }

    }
}
