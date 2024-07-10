using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace parc_auto_v1.Models
{
    public class Demandeur
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Role { get; set; }

        // Navigation property
        public virtual ICollection<Demande> Demandes { get; set; }
    }
}
