namespace Adambnb.DTOs
{
    public class LocationV2DTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string LandlordAvatarURL { get; set; }
        public int Type { get; set; }
        public float Price { get; set; }
    }
}