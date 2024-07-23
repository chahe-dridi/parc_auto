using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace parc_auto_v1.Models
{
    public class Voiture
    {
        public int Id { get; set; }

        [Required]
        public string Matricule { get; set; }

        [Required]
        public string TypeVoiture { get; set; }

        public int MarqueId { get; set; }
        public Marque Marque { get; set; }

        public int ModeleId { get; set; }
        public Modele Modele { get; set; }

        public int Km { get; set; }

        [Required]
        public string Carburant { get; set; }

        [Required]
        public string Etat { get; set; }

        [Required]
        public string Disponibilite { get; set; }

        public ICollection<VisiteTechnique> VisiteTechniques { get; set; }
        public ICollection<Vidange> Vidanges { get; set; }
        public ICollection<Sinistre> Sinistres { get; set; }
        public ICollection<Assurance> Assurances { get; set; }
        public ICollection<Vignette> Vignettes { get; set; }

        public ICollection<Demandes> Demandes { get; set; }

    }
}
