﻿using System.ComponentModel.DataAnnotations;

namespace MediiDeProgramarePROIECT.Models
{
    public class Waiter
    {
        public int ID { get; set; }

        [Display(Name = "Chelner")]
        public string Name { get; set; }

        // Relație cu mesele
        public ICollection<Table>? Tables { get; set; }
    }
}
