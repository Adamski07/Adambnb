namespace Adambnb.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CostumerId { get; set; } 
        public Costumer Costumer { get; set; }
        public float Discount { get; set; }
        public int LocationId { get; set; } 
    }
}