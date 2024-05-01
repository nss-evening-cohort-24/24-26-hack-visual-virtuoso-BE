using HackVisualVirtuosoBE.Models;

namespace HackVisualVirtuosoBE.Models
{
    public class ArtworkTag
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public int TagId { get; set; }
        public virtual Artwork? Artwork { get; set; }
        public virtual Tag? Tag { get; set; }
       
    }
}