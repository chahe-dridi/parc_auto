using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parc_auto_v1.Models
{
    public class Demandes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(50)] // Change this if IdEmploye is longer
        public string IdEmploye { get; set; } // Changed to string

        [Required]
        [StringLength(100)]
        public string AffectationDepartement { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeVoiture { get; set; }

        [Required]
        [StringLength(255)]
        public string Destination { get; set; }

        [Required]
<<<<<<< HEAD
        [Display(Name = "Date Depart")]
        [DataType(DataType.Date)]
        public DateTime DateDepart { get; set; }

        [Required]
        [Display(Name = "Date Depart")]
        [DataType(DataType.Date)]
=======
        public DateTime DateDepart { get; set; }

        [Required]
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        public DateTime DateArrivee { get; set; }

       

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Mission { get; set; }

        public int? VoitureId { get; set; }

        // Navigation property
        [ForeignKey("VoitureId")]
        public virtual Voiture Voiture { get; set; }

        // Etat can be null
        [StringLength(50)]
        public string? Etat { get; set; } // Changed to nullable
<<<<<<< HEAD


        public int? Kilometrage { get; set; } // Nullable integer property
=======
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
    }



}
