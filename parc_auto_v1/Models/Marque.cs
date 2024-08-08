using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace parc_auto_v1.Models
{
    public class Marque
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public ICollection<Voiture> Voitures { get; set; }
        public ICollection<Modele> Modeles { get; set; } // Add this line
    }
}
