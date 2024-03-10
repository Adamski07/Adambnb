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
                    Title = "De Boerenhoeve",
                    Subtitle = "Lekker veel ruimte",
                    Description = "De camping ligt verscholen achter de boerderij in de polder. Geniet van de rust en ruimte op De Boerenhoeve, waar de natuur je omringt en de frisse lucht je verwelkomt. Onze comfortabele appartementen bieden een thuis weg van huis, met moderne voorzieningen en een sfeervolle inrichting. Ontspan op het terras en bewonder het prachtige uitzicht op de omringende weilanden. Of verken de nabijgelegen wandel- en fietspaden voor een onvergetelijke ervaring in de natuur. We heten je van harte welkom op De Boerenhoeve!",
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
                    Title = "Zeezicht Appartement",
                    Subtitle = "Prachtig uitzicht op de zee",
                    Description = "Ervaar de ultieme vakantie aan de kust in ons Zeezicht Appartement. Geniet van adembenemende uitzichten op de zee vanuit je ruime en comfortabele accommodatie. Ontspan op het balkon en luister naar het rustgevende geluid van de golven. Het appartement is smaakvol ingericht en voorzien van moderne voorzieningen. Verken de nabijgelegen stranden, restaurants en bezienswaardigheden voor een onvergetelijke vakantie aan zee.",
                    Type = Location.LocationType.Apartment,
                    Rooms = 3,
                    NumberOfGuests = 6,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Tv, Location.Features.Bath },
                    PricePerDay = 150.0f,
                    LandLordId = 2
                },
                new Location
                {
                    Id = 3,
                    Title = "Groene Oase Chalet",
                    Subtitle = "Omgeven door natuur",
                    Description = "Ontsnap aan de drukte en omarm de natuur in ons Groene Oase Chalet. Dit charmante chalet is omgeven door weelderig groen en biedt een rustige toevluchtsoord voor natuurliefhebbers. Het chalet is voorzien van alle gemakken en beschikt over een eigen tuin waar je kunt genieten van de flora en fauna. Verken de wandelpaden, observeer vogels en kom helemaal tot rust in deze groene oase.",
                    Type = Location.LocationType.Chalet,
                    Rooms = 1,
                    NumberOfGuests = 2,
                    FeaturesList = new List<Location.Features> { Location.Features.PetsAllowed, Location.Features.Breakfast },
                    PricePerDay = 120.0f,
                    LandLordId = 1
                },
                new Location
                {
                    Id = 4,
                    Title = "Historisch Stadsappartement",
                    Subtitle = "Verken de oude stad",
                    Description = "Verblijf in stijl in ons Historisch Stadsappartement, gelegen in het hart van de oude stad. Het appartement combineert moderne luxe met historische charme en biedt een unieke ervaring. Wandel door smalle steegjes, ontdek historische bezienswaardigheden en proef lokale gerechten in de nabijgelegen restaurants. Het appartement is smaakvol ingericht en voorzien van alle moderne gemakken voor een comfortabel en cultureel verblijf.",
                    Type = Location.LocationType.Apartment,
                    Rooms = 2,
                    NumberOfGuests = 4,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Tv },
                    PricePerDay = 130.0f,
                    LandLordId = 1
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
