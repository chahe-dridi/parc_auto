using System;
using System.ComponentModel.DataAnnotations;

namespace parc_auto_v1.Models
{
    public class Vignette
    {
        public int Id { get; set; }

        [Display(Name = "Date d'échéance")]
        [DataType(DataType.Date)]
        public DateTime DateEchance { get; set; }

        [Display(Name = "Date valide")]
        [DataType(DataType.Date)]
        public DateTime DateValide { get; set; }

        public bool Alert { get; set; }

        [Display(Name = "Prix unitaire")]
        public decimal PrixUnitaire { get; set; }

        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
    }
<<<<<<< HEAD

=======
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
}
