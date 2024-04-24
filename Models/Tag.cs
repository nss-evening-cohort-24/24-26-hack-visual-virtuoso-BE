namespace HackVisualVirtuosoBE.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<ArtworkTag> Artwork { get; set; }
    }
}