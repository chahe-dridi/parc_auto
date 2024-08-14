<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace parc_auto_v1.Models
=======
﻿namespace parc_auto_v1.Models
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
{
    public class VisiteTechnique
    {
        public int Id { get; set; }
<<<<<<< HEAD


       
        [Display(Name = "Date d'échéance")]
        [DataType(DataType.Date)]
        public DateTime DateEchance { get; set; }



        [Display(Name = "Date Valide")]
        [DataType(DataType.Date)]
        public DateTime DateValide { get; set; }

=======
        public DateTime DateEchance { get; set; }
        public DateTime DateValide { get; set; }
>>>>>>> 2078fab796a7e7e564eda3af7f783cc9f51e6122
        public bool Alert { get; set; }
        public decimal PrixUnitaire { get; set; }

        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
    }
}
