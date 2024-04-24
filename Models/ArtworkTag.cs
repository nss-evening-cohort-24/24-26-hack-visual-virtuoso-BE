namespace HackVisualVirtuosoBE.Models
{
    public class ArtworkTag
    {
        public int Id { get; set; }
        public Artwork? Artwork { get; set; }
        public Tag? Tag { get; set; }
    }
}