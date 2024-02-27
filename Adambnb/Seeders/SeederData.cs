using System;
using System.Collections.Generic;
using System.Linq;
using Adambnb.Models;
using Microsoft.EntityFrameworkCore;

namespace Adambnb.Seeders
{
    public static class SeederData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed Customers
            modelBuilder.Entity<Costumer>().HasData(
                new Costumer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                new Costumer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }
            );

            // Seed Landlords
            modelBuilder.Entity<LandLord>().HasData(
                new LandLord { Id = 1, FirstName = "Landlord1", LastName = "Doe", Age = 35 },
                new LandLord { Id = 2, FirstName = "Landlord2", LastName = "Smith", Age = 40 }
            );

            // Seed Images
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "image1.jpg", IsCover = true, LocationId = 1, LandLordId = 1 },
                new Image { Id = 2, Url = "image2.jpg", IsCover = true, LocationId = 2, LandLordId = 2 }
            );

            // Seed Locations
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Title = "Location1",
                    Subtitle = "Subtitle1",
                    Description = "Description1",
                    Type = Location.LocationType.Apartment,
                    Rooms = 2,
                    NumberOfGuests = 4,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Tv },
                    PricePerDay = 100.0f,
                    LandLordId = 1
                },
                new Location
                {
                    Id = 2,
                    Title = "Location2",
                    Subtitle = "Subtitle2",
                    Description = "Description2",
                    Type = Location.LocationType.House,
                    Rooms = 3,
                    NumberOfGuests = 6,
                    FeaturesList = new List<Location.Features> { Location.Features.Smoking, Location.Features.PetsAllowed },
                    PricePerDay = 150.0f,
                    LandLordId = 2
                }
            );

            // Seed Reservations
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, LocationId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3), CostumerId = 1, Discount = 10.0f },
                new Reservation { Id = 2, LocationId = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), CostumerId = 2, Discount = 5.0f }
            );
        }
    }
}
