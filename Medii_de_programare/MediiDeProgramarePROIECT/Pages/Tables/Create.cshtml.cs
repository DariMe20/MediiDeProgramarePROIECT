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
using Microsoft.AspNetCore.Authorization;

namespace MediiDeProgramarePROIECT.Pages.Tables
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : TableSchedulesPageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public CreateModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["WaiterID"] = new SelectList(_context.Waiter, "ID", "Name");
            ViewData["ZoneID"] = new SelectList(_context.Zone, "ID", "Name");

            var table = new Table();
            table.BookingSchedules = new List<BookingSchedule>();
            PopulateAssignedScheduleData(_context, table);
            return Page();
        }

        [BindProperty]
        public Table Table { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedSchedules)
        {
            var newTable = new Table();
            if (selectedSchedules != null)
            {
                newTable.BookingSchedules = new List<BookingSchedule>();
                foreach (var sched in selectedSchedules)
                {
                    var schedToAdd = new BookingSchedule
                    {
                        ScheduleID = int.Parse(sched)
                    };
                    newTable.BookingSchedules.Add(schedToAdd);
                }
            }
            Table.BookingSchedules = newTable.BookingSchedules;
            _context.Table.Add(Table);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
