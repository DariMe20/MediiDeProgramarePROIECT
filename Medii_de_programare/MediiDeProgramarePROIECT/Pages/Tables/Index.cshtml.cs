using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Pages.Tables
{
    public class IndexModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public IndexModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        public IList<Table> Table { get; set; }

        public TableData TableD { get; set; }
        public int TableID { get; set; }
        public int ScheduleID { get; set; }



        public string ZoneSort { get; set; }

        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? scheduleID, string sortOrder, string searchString)
        {
            TableD = new TableData();
            ZoneSort = String.IsNullOrEmpty(sortOrder) ? "zone_cres " : "";
            {
                TableD.Tables = await _context.Table
                    .Include(t => t.Waiter)
                    .Include(t => t.Zone)
                    .Include(t => t.BookingSchedules)
                        .ThenInclude(bs => bs.Schedule)
                    .AsNoTracking()
                    .ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    TableD.Tables = TableD.Tables.Where(s => s.Zone.Name.Contains(searchString)

                   || s.Zone.Name.Contains(searchString));

                };
            }
        }

    }
}
