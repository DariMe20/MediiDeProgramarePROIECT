using System;
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
        public DbSet<MediiDeProgramarePROIECT.Models.Table>? Table { get; set; }
        public DbSet<MediiDeProgramarePROIECT.Models.Waiter>? Waiter { get; set; }
        public DbSet<MediiDeProgramarePROIECT.Models.Zone>? Zone { get; set; }
        public DbSet<MediiDeProgramarePROIECT.Models.Schedule>? Schedule { get; set; }
        public DbSet<MediiDeProgramarePROIECT.Models.BookingSchedule>? BookingSchedule { get; set; }
        public DbSet<MediiDeProgramarePROIECT.Models.Client>? Client { get; set; }
        public DbSet<MediiDeProgramarePROIECT.Models.Reservation>? Reservation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .HasOne(e => e.Reservation)
            .WithOne(e => e.Table)
                .HasForeignKey<Reservation>("ReservationID");
        }
    }
}
