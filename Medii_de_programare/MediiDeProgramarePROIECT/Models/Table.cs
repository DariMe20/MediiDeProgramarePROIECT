using MediiDeProgramarePROIECT.Migrations;
using System.ComponentModel.DataAnnotations;

namespace MediiDeProgramarePROIECT.Models
{
    public class Table
    {
        public int ID { get; set; }

        [Display(Name = "Locuri disponibile")]
        [Range(1, 15, ErrorMessage = "The number of seats must be between 1 and 15")]

        public int Seats { get; set; }

        // Cheie străină pentru Waiter
        [Display(Name = "Chelner Responsabil")]
        public int? WaiterID { get; set; }
        public Waiter? Waiter { get; set; }

        // Cheie străină pentru Zone
        [Display(Name = "Chelner")]
        public int? ZoneID { get; set; }
        public Zone? Zone { get; set; }

        // Programul pentru rezervări
        [Display(Name = "Disponibilitate")]
        


        public int? ReservationID { get; set; }
        public Reservation? Reservation { get; set; }


        

        public ICollection<BookingSchedule>? BookingSchedules { get; set; }
    }

}
