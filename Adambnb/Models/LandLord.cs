namespace Adambnb.Models
{
    public class LandLord
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public Image Avatar { get; set; }
        public List<Location> Locations { get; set; }
    }
}
