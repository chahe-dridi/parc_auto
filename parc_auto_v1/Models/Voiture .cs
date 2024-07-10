namespace parc_auto_v1.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string TypeVoiture { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Km { get; set; }
        public string Carburant { get; set; }
        public string Etat { get; set; }
        public string Disponibilite { get; set; }

        public ICollection<VisiteTechnique> VisiteTechniques { get; set; }
        public ICollection<Vidange> Vidanges { get; set; }
        public ICollection<Sinistre> Sinistres { get; set; }
        public ICollection<Assurance> Assurances { get; set; }
        public ICollection<Vignette> Vignettes { get; set; }
    }
}
