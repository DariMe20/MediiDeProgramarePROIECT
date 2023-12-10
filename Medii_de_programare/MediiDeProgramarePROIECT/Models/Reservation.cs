using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace MediiDeProgramarePROIECT.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? TableID { get; set; }
        public Table? Table { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Reservation Date")]
        public DateTime ReturnDate { get; set; }
    }
}
