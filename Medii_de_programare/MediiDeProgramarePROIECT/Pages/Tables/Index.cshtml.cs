﻿using System;
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

        public async Task OnGetAsync()
        {
            TableD = new TableData
            {
                Tables = await _context.Table
                    .Include(t => t.Waiter)
                    .Include(t => t.Zone)
                    .Include(t => t.BookingSchedules)
                        .ThenInclude(bs => bs.Schedule)
                    .AsNoTracking()
                    .ToListAsync()
            };
        }
    }

}
