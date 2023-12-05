using System.ComponentModel.DataAnnotations;

namespace MediiDeProgramarePROIECT.Models
{
    public class BookingSchedule
    {
        public int ID { get; set; }

        [Display(Name = "Day of Week")]
        public DayOfWeek DayOfWeek { get; set; }

        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }
    }
}
