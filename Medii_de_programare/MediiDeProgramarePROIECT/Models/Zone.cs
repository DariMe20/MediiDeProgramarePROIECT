using System.ComponentModel.DataAnnotations;

namespace MediiDeProgramarePROIECT.Models
{
    public class Zone
    {
        public int ID { get; set; }

        [Display(Name = "Zona")]
        public string Name { get; set; }

        // Relație cu mesele
        public ICollection<Table>? Tables { get; set; }
    }
}
