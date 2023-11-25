using System.ComponentModel.DataAnnotations;

namespace MediiDeProgramarePROIECT.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        public string Location { get; set; }

        public string Chef {  get; set; }

        [Display(Name = "Client Max Capacity")]
        public decimal Max_Person { get; set; }

    }
}
