﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Data;
using MediiDeProgramarePROIECT.Models;
using Microsoft.AspNetCore.Authorization;

namespace MediiDeProgramarePROIECT.Pages.Zones
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext _context;

        public IndexModel(MediiDeProgramarePROIECT.Data.MediiDeProgramarePROIECTContext context)
        {
            _context = context;
        }

        public IList<Zone> Zone { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Zone != null)
            {
                Zone = await _context.Zone.ToListAsync();
            }
        }
    }
}
