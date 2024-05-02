namespace HackVisualVirtuosoBE.Dtos
{
    public class ArtworkTagDto
    {
        public int Id { get; set; }
        public int ArtworkId { get; set; }
        public int TagId { get; set; }
        public ArtworkDto Artwork { get; set; }
        public TagDto Tag { get; set; }
    }
}