using HackVisualVirtuosoBE.Models;

namespace HackVisualVirtuosoBE.Dtos
{
    public class UpdateArtworkDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set;}
        public List<ArtworkTag> Tags { get; set; }
    }
}