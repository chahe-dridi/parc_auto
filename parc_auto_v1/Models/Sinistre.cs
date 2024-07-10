namespace parc_auto_v1.Models
{
    public class Sinistre
    {
        public int Id { get; set; }
        public DateTime DateDommage { get; set; }
        public string Observation { get; set; }
        public string Description { get; set; }
        public bool AcceptationPourFixe { get; set; }
        public string EtatDeVoiture { get; set; }
        public long PrixFixe { get; set; }

        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
    }
}
