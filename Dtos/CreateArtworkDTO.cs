namespace HackVisualVirtuosoBE.Dtos
{
    public class CreateArtworkDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl {get; set; }
        public List<int> TagIds { get; set; }
    }
}