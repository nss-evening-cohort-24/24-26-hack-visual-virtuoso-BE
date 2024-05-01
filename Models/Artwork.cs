using System.Security.Cryptography.X509Certificates;

namespace HackVisualVirtuosoBE.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

        public string? UserId { get; set; }
        public virtual ICollection<ArtworkTag>? Tags { get; set; }

       // public List<ArtworkTag> Tags { get; set; }
    }
}