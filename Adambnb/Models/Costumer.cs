namespace Adambnb.Models
{
    public class Costumer
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Email { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
