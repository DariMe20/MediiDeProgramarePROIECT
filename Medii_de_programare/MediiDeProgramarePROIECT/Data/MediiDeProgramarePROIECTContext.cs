﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediiDeProgramarePROIECT.Models;

namespace MediiDeProgramarePROIECT.Data
{
    public class MediiDeProgramarePROIECTContext : DbContext
    {
        public MediiDeProgramarePROIECTContext (DbContextOptions<MediiDeProgramarePROIECTContext> options)
            : base(options)
        {
        }

        public DbSet<MediiDeProgramarePROIECT.Models.Restaurant> Restaurant { get; set; } = default!;
    }
}