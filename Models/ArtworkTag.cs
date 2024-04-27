using HackVisualVirtuosoBE.Models;

namespace HackVisualVirtuosoBE.Models
{
    public class ArtworkTag
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public int TagId { get; set; }
        public Artwork? Artwork { get; set; }
        public Tag? Tag { get; set; }
       
    }
}