using System.Text.Json.Serialization;

namespace Adambnb.Models
{
    public class Location
    {
        public enum LocationType
        {
            Apartment,
            Cottage,
            Chalet,
            Room,
            Hotel,
            House
        }

        public enum Features
        {
            Smoking,
            PetsAllowed,
            Wifi,
            Tv,
            Bath,
            Breakfast
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LocationType Type { get; set; }
        public int Rooms { get; set; }
        public int NumberOfGuests { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public List<Features> FeaturesList{ get; set; }
        public List<Image> Images { get; set; }
        public float PricePerDay { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int LandLordId { get; set; } 
        public LandLord LandLord { get; set; }

    }
}
