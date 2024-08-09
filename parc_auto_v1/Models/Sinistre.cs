using System;
using System.ComponentModel.DataAnnotations;

namespace parc_auto_v1.Models
{
    public class Sinistre
    {
        public int Id { get; set; }

        [Display(Name = "Date de dommage")]
        [DataType(DataType.Date)]
        public DateTime DateDommage { get; set; } // Keeping DateTime, but you can change to DateOnly if needed

        [Display(Name = "Observation")]
        public string Observation { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Acceptation pour prix fixe")]
        public bool AcceptationPourFixe { get; set; }

        [Display(Name = "État de voiture")]
        public string EtatDeVoiture { get; set; }

        [Display(Name = "Prix fixe")]
        public long PrixFixe { get; set; }

        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
    }
}
