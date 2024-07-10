namespace parc_auto_v1.Models
{
    public class Vignette
    {
        public int Id { get; set; }
        public DateTime DateEchance { get; set; }
        public DateTime DateValide { get; set; }
        public bool Alert { get; set; }
        public decimal PrixUnitaire { get; set; }

        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
    }
}
