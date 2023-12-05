using System.ComponentModel.DataAnnotations;

namespace MediiDeProgramarePROIECT.Models
{
    public class Table
    {
        public int ID { get; set; }

        [Display(Name = "Available Seats")]
        [Range(1, 15, ErrorMessage = "The number of seats must be between 1 and 15")]

        public int Seats { get; set; }

        // Cheie străină pentru Waiter
        public int? WaiterID { get; set; }
        public Waiter? Waiter { get; set; }

        // Cheie străină pentru Zone
        public int? ZoneID { get; set; }
        public Zone? Zone { get; set; }

        // Programul pentru rezervări
        public List<BookingSchedule> BookingSchedules { get; set; }
    }
}
