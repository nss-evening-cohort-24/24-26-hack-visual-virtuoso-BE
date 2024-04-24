namespace HackVisualVirtuosoBE.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; }

        public List<ArtworkTag> Tags { get; set; }
    }
}