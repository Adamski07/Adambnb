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
                new LandLord { Id = 2, FirstName = "Landlord2", LastName = "Smith", Age = 40 },
                new LandLord { Id = 3, FirstName = "John", LastName = "Doe", Age = 35 },
                new LandLord { Id = 4, FirstName = "Jane", LastName = "Smith", Age = 40 },
                new LandLord { Id = 5, FirstName = "Adam", LastName = "Johnson", Age = 45 },
                new LandLord { Id = 6, FirstName = "Emily", LastName = "Brown", Age = 38 },
                new LandLord { Id = 7, FirstName = "Michael", LastName = "Davis", Age = 42 },
                new LandLord { Id = 8, FirstName = "Sarah", LastName = "Wilson", Age = 37 },
                new LandLord { Id = 9, FirstName = "Robert", LastName = "Martinez", Age = 39 },
                new LandLord { Id = 10, FirstName = "Laura", LastName = "Garcia", Age = 41 },
                new LandLord { Id = 11, FirstName = "Daniel", LastName = "Robinson", Age = 36 },
                new LandLord { Id = 12, FirstName = "Lisa", LastName = "Miller", Age = 43 },
                new LandLord { Id = 13, FirstName = "William", LastName = "Hernandez", Age = 44 },
                new LandLord { Id = 14, FirstName = "Patricia", LastName = "Lopez", Age = 33 },
                new LandLord { Id = 15, FirstName = "Richard", LastName = "Lewis", Age = 39 },
                new LandLord { Id = 16, FirstName = "Karen", LastName = "Clark", Age = 34 },
                new LandLord { Id = 17, FirstName = "Jason", LastName = "Young", Age = 32 },
                new LandLord { Id = 18, FirstName = "Adam", LastName = "Lin", Age = 20 },
                new LandLord { Id = 19, FirstName = "Lo", LastName = "La", Age = 54 },
                new LandLord { Id = 20, FirstName = "Tom", LastName = "Voldoende", Age = 22 },
                new LandLord { Id = 21, FirstName = "Rico", LastName = "Sof", Age = 34 },
                new LandLord { Id = 22, FirstName = "Gert", LastName = "Jan", Age = 23 },
                new LandLord { Id = 23, FirstName = "Dit", LastName = "Vak", Age = 23 },
                new LandLord { Id = 24, FirstName = "Is", LastName = "Leuk", Age = 23 },
                new LandLord { Id = 25, FirstName = "Hans", LastName = "Kazan", Age = 45 },
                new LandLord { Id = 26, FirstName = "Mohammed", LastName = "Salah", Age = 54 },
                new LandLord { Id = 27, FirstName = "Han", LastName = "fee", Age = 65 },
                new LandLord { Id = 28, FirstName = "DA", LastName = "effe", Age = 43 },
                new LandLord { Id = 29, FirstName = "da", LastName = "vdfv", Age = 65 },
                new LandLord { Id = 30, FirstName = "dw", LastName = "t4", Age = 64 },
                new LandLord { Id = 31, FirstName = "Jop", LastName = "rt", Age = 34 },
                new LandLord { Id = 32, FirstName = "wceadweas", LastName = "trer", Age = 32 },
                new LandLord { Id = 33, FirstName = "ef", LastName = "gh", Age = 32 },
                new LandLord { Id = 34, FirstName = "feef", LastName = "hdfg", Age = 43 },
                new LandLord { Id = 35, FirstName = "ef", LastName = "gh", Age = 32 },
                new LandLord { Id = 36, FirstName = "feef", LastName = "hdfg", Age = 43 }
            );

            // Seed Images
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "https://watismijnhuiswaard.com/wp-content/uploads/2021/06/Boerderij-1024x512.jpg", IsCover = true, LocationId = 1, LandLordId = 1 },
                new Image { Id = 2, Url = "https://www.egmondverhuur.nl/sites/egmondverhuur/files/styles/slide/public/images/appartementen-met-zeezicht_0.jpg?itok=iAWaBQd2", IsCover = true, LocationId = 2, LandLordId = 2 },
                new Image { Id = 3, Url = "https://images.unsplash.com/photo-1523217582562-09d0def993a6?q=80&w=2080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", IsCover = true, LocationId = 6, LandLordId = 3 },
                new Image { Id = 4, Url = "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?q=80&w=2075&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", IsCover = true, LocationId = 7, LandLordId = 4 },
                new Image { Id = 5, Url = "https://images.unsplash.com/photo-1583608205776-bfd35f0d9f83?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", IsCover = true, LocationId = 8, LandLordId = 5 },
                new Image { Id = 6, Url = "https://generatorfun.com/code/uploads/Random-House-image-15.jpg", IsCover = true, LocationId = 9, LandLordId = 6 },
                new Image { Id = 7, Url = "https://generatorfun.com/code/uploads/Random-House-image-1.jpg", IsCover = true, LocationId = 10, LandLordId = 7 },
                new Image { Id = 8, Url = "https://generatorfun.com/code/uploads/Random-House-image-13.jpg", IsCover = true, LocationId = 11, LandLordId = 8 },
                new Image { Id = 9, Url = "https://generatorfun.com/code/uploads/Random-House-image-13.jpg", IsCover = true, LocationId = 12, LandLordId = 9 },
                new Image { Id = 10, Url = "https://generatorfun.com/code/uploads/Random-House-image-10.jpg", IsCover = true, LocationId = 13, LandLordId = 10 },
                new Image { Id = 11, Url = "https://generatorfun.com/code/uploads/Random-House-image-19.jpg", IsCover = true, LocationId = 14, LandLordId = 11 },
                new Image { Id = 12, Url = "https://generatorfun.com/code/uploads/Random-House-image-9.jpg", IsCover = true, LocationId = 15, LandLordId = 12 },
                new Image { Id = 16, Url = "https://generatorfun.com/code/uploads/Random-House-image-5.jpg", IsCover = true, LocationId = 3, LandLordId = 16 },
                new Image { Id = 17, Url = "https://generatorfun.com/code/uploads/Random-House-image-10.jpg", IsCover = true, LocationId = 4, LandLordId = 17 },
                new Image { Id = 18, Url = "https://generatorfun.com/code/uploads/Random-House-image-19.jpg", IsCover = true, LocationId = 5, LandLordId = 18 },

                new Image { Id = 19, Url = "https://generatorfun.com/code/uploads/Random-House-image-9.jpg", IsCover = false, LocationId = 1, LandLordId = 19 },
                new Image { Id = 20, Url = "https://generatorfun.com/code/uploads/Random-House-image-5.jpg", IsCover = false, LocationId = 2, LandLordId = 20 },
                new Image { Id = 21, Url = "https://generatorfun.com/code/uploads/Random-House-image-10.jpg", IsCover = false, LocationId = 3, LandLordId = 21 },
                new Image { Id = 22, Url = "https://generatorfun.com/code/uploads/Random-House-image-19.jpg", IsCover = false, LocationId = 4, LandLordId = 22 },
                new Image { Id = 23, Url = "https://generatorfun.com/code/uploads/Random-House-image-9.jpg", IsCover = false, LocationId = 5, LandLordId = 23 },
                new Image { Id = 24, Url = "https://generatorfun.com/code/uploads/Random-House-image-5.jpg", IsCover = false, LocationId = 6, LandLordId = 24 },
                new Image { Id = 25, Url = "https://generatorfun.com/code/uploads/Random-House-image-10.jpg", IsCover = false, LocationId = 7, LandLordId = 25 },
                new Image { Id = 26, Url = "https://generatorfun.com/code/uploads/Random-House-image-19.jpg", IsCover = false, LocationId = 8, LandLordId = 26 },
                new Image { Id = 27, Url = "https://generatorfun.com/code/uploads/Random-House-image-9.jpg", IsCover = false, LocationId = 9, LandLordId = 27 },
                new Image { Id = 28, Url = "https://generatorfun.com/code/uploads/Random-House-image-5.jpg", IsCover = false, LocationId = 10, LandLordId = 28 },
                new Image { Id = 29, Url = "https://generatorfun.com/code/uploads/Random-House-image-10.jpg", IsCover = false, LocationId = 11, LandLordId = 29 },
                new Image { Id = 30, Url = "https://generatorfun.com/code/uploads/Random-House-image-19.jpg", IsCover = false, LocationId = 12, LandLordId = 30 },
                new Image { Id = 31, Url = "https://generatorfun.com/code/uploads/Random-House-image-9.jpg", IsCover = false, LocationId = 13, LandLordId = 31 },
                new Image { Id = 32, Url = "https://generatorfun.com/code/uploads/Random-House-image-5.jpg", IsCover = false, LocationId = 14, LandLordId = 32 },
                new Image { Id = 33, Url = "https://generatorfun.com/code/uploads/Random-House-image-10.jpg", IsCover = false, LocationId = 15, LandLordId = 33 },
                new Image { Id = 34, Url = "https://generatorfun.com/code/uploads/Random-House-image-19.jpg", IsCover = false, LocationId = 1, LandLordId = 34 },
                new Image { Id = 35, Url = "https://generatorfun.com/code/uploads/Random-House-image-9.jpg", IsCover = false, LocationId = 2, LandLordId = 35 },
                new Image { Id = 36, Url = "https://generatorfun.com/code/uploads/Random-House-image-5.jpg", IsCover = false, LocationId = 3, LandLordId = 36 }

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
                },
                new Location
                {
                    Id = 5,
                    Title = "Rustic Cottage by the Lake",
                    Subtitle = "Tranquil waterside retreat",
                    Description = "Escape to this charming cottage nestled by the serene lake. Enjoy the rustic charm and peaceful surroundings with stunning lake views. The cottage features a cozy interior with a fireplace, perfect for romantic getaways or family vacations. Explore nearby hiking trails, go fishing, or simply unwind on the private dock. This retreat promises a rejuvenating experience in nature's embrace.",
                    Type = Location.LocationType.Cottage,
                    Rooms = 2,
                    NumberOfGuests = 4,
                    FeaturesList = new List<Location.Features> { Location.Features.PetsAllowed, Location.Features.Wifi },
                    PricePerDay = 110.0f,
                    LandLordId = 2
                },
                new Location
                {
                    Id = 6,
                    Title = "Urban Loft in Downtown",
                    Subtitle = "Modern city living",
                    Description = "Live in style in this sleek urban loft situated in the heart of downtown. Experience contemporary living with high ceilings, industrial-chic decor, and panoramic city views. The loft is fully equipped with state-of-the-art amenities and is ideal for professionals or urban explorers seeking convenience and luxury. Step outside to trendy cafes, art galleries, and nightlife hotspots for a vibrant city experience.",
                    Type = Location.LocationType.Apartment,
                    Rooms = 1,
                    NumberOfGuests = 2,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Tv },
                    PricePerDay = 180.0f,
                    LandLordId = 3
                },
                new Location
                {
                    Id = 7,
                    Title = "Secluded Mountain Retreat",
                    Subtitle = "A sanctuary in the mountains",
                    Description = "Embrace tranquility at this secluded mountain retreat, surrounded by majestic peaks and lush forests. The cabin offers a cozy atmosphere with wood-panelled interiors, a crackling fireplace, and breathtaking mountain views from the deck. Hike scenic trails, spot wildlife, or simply relax in the hot tub under the starlit sky. This retreat is perfect for nature enthusiasts and those seeking a peaceful mountain escape.",
                    Type = Location.LocationType.Chalet,
                    Rooms = 3,
                    NumberOfGuests = 6,
                    FeaturesList = new List<Location.Features> { Location.Features.PetsAllowed, Location.Features.Breakfast },
                    PricePerDay = 200.0f,
                    LandLordId = 2
                },
                new Location
                {
                    Id = 8,
                    Title = "Luxury Beachfront Villa",
                    Subtitle = "Exclusive oceanfront living",
                    Description = "Indulge in luxury at this beachfront villa boasting panoramic ocean views and direct beach access. The villa features spacious rooms, elegant decor, and a private pool overlooking the sea. Pamper yourself with in-villa spa treatments or dine al fresco on the terrace with sunset views. Explore pristine beaches, water sports, and local seafood cuisine for a luxurious coastal retreat.",
                    Type = Location.LocationType.House,
                    Rooms = 4,
                    NumberOfGuests = 8,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Bath },
                    PricePerDay = 500.0f,
                    LandLordId = 1
                },
                new Location
                {
                    Id = 9,
                    Title = "Historic Manor House",
                    Subtitle = "Elegant heritage accommodation",
                    Description = "Step back in time at this historic manor house, offering grandeur and elegance amidst sprawling gardens and ancient architecture. The manor features opulent rooms, antique furnishings, and impeccable service for a luxurious stay. Stroll through manicured gardens, enjoy afternoon tea in the drawing room, or explore nearby historic landmarks. This estate promises a refined retreat steeped in history.",
                    Type = Location.LocationType.Hotel,
                    Rooms = 10,
                    NumberOfGuests = 20,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Breakfast },
                    PricePerDay = 1000.0f,
                    LandLordId = 3
                },
                new Location
                {
                    Id = 10,
                    Title = "Cozy Ski Chalet",
                    Subtitle = "Winter wonderland getaway",
                    Description = "Escape to this cozy ski chalet nestled in a picturesque alpine village. The chalet features timber interiors, a roaring fireplace, and stunning mountain views from the balcony. Ski-in, ski-out access makes it perfect for winter sports enthusiasts, while summer visitors can hike scenic trails or relax in the sauna. Enjoy après-ski in the village or unwind with hot chocolate by the fire.",
                    Type = Location.LocationType.Chalet,
                    Rooms = 3,
                    NumberOfGuests = 6,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Tv, Location.Features.Bath },
                    PricePerDay = 250.0f,
                    LandLordId = 2
                },
                new Location
                {
                    Id = 11,
                    Title = "Quaint Countryside B&B",
                    Subtitle = "Charming bed and breakfast",
                    Description = "Experience country charm at this quaint bed and breakfast nestled in rolling hills. The B&B offers cozy rooms with floral decor, homemade breakfasts, and a warm, welcoming atmosphere. Explore nearby vineyards, go horseback riding, or simply relax in the garden with a book. This retreat is ideal for couples seeking a peaceful rural escape.",
                    Type = Location.LocationType.House,
                    Rooms = 5,
                    NumberOfGuests = 10,
                    FeaturesList = new List<Location.Features> { Location.Features.Breakfast },
                    PricePerDay = 150.0f,
                    LandLordId = 1
                },
                new Location
                {
                    Id = 12,
                    Title = "Lakeview Penthouse Suite",
                    Subtitle = "Luxury lakeside living",
                    Description = "Enjoy unparalleled luxury in this lakeview penthouse suite boasting floor-to-ceiling windows and a private terrace overlooking the water. The suite features contemporary design, high-end amenities, and exclusive access to a rooftop pool and spa. Indulge in gourmet dining, yacht cruises, or lakeside walks for a sophisticated lakeside retreat.",
                    Type = Location.LocationType.Apartment,
                    Rooms = 2,
                    NumberOfGuests = 4,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.Tv, Location.Features.Bath },
                    PricePerDay = 350.0f,
                    LandLordId = 3
                },
                new Location
                {
                    Id = 13,
                    Title = "Eco-Friendly Treehouse",
                    Subtitle = "Off-grid wilderness escape",
                    Description = "Immerse yourself in nature at this eco-friendly treehouse retreat hidden deep in the forest. The treehouse offers a unique stay with sustainable design, panoramic forest views, and tranquil surroundings. Disconnect from technology, hike through ancient woods, or stargaze from the treehouse deck. This retreat is perfect for eco-conscious travelers seeking a back-to-nature experience.",
                    Type = Location.LocationType.Cottage,
                    Rooms = 1,
                    NumberOfGuests = 2,
                    FeaturesList = new List<Location.Features> { Location.Features.PetsAllowed },
                    PricePerDay = 80.0f,
                    LandLordId = 2
                },
                new Location
                {
                    Id = 14,
                    Title = "Modern City Studio",
                    Subtitle = "Convenient urban living",
                    Description = "Experience modern living in this sleek city studio located in a bustling downtown district. The studio features minimalist decor, a compact kitchenette, and access to a rooftop garden with city skyline views. Explore nearby cafes, shops, and cultural attractions or retreat to your stylish urban oasis after a day of city exploration.",
                    Type = Location.LocationType.Room,
                    Rooms = 1,
                    NumberOfGuests = 2,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi },
                    PricePerDay = 100.0f,
                    LandLordId = 1
                },
                new Location
                {
                    Id = 15,
                    Title = "Lakeside Log Cabin",
                    Subtitle = "Rustic lakeside retreat",
                    Description = "Escape to this charming log cabin nestled on the shores of a tranquil lake. The cabin features rustic wood interiors, a stone fireplace, and a private dock for fishing and boating. Enjoy serene lake views from the porch swing or explore nearby hiking trails and wildlife spotting opportunities. This cabin promises a cozy retreat in nature's embrace.",
                    Type = Location.LocationType.Chalet,
                    Rooms = 2,
                    NumberOfGuests = 4,
                    FeaturesList = new List<Location.Features> { Location.Features.Wifi, Location.Features.PetsAllowed },
                    PricePerDay = 150.0f,
                    LandLordId = 3
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
