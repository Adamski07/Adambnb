using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Adambnb.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandLords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandLords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    FeaturesList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<float>(type: "real", nullable: false),
                    LandLordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_LandLords_LandLordId",
                        column: x => x.LandLordId,
                        principalTable: "LandLords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCover = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LandLordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_LandLords_LandLordId",
                        column: x => x.LandLordId,
                        principalTable: "LandLords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostumerId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "Doe" },
                    { 2, "jane@example.com", "Jane", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "LandLords",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 35, "Landlord1", "Doe" },
                    { 2, 40, "Landlord2", "Smith" },
                    { 3, 35, "John", "Doe" },
                    { 4, 40, "Jane", "Smith" },
                    { 5, 45, "Adam", "Johnson" },
                    { 6, 38, "Emily", "Brown" },
                    { 7, 42, "Michael", "Davis" },
                    { 8, 37, "Sarah", "Wilson" },
                    { 9, 39, "Robert", "Martinez" },
                    { 10, 41, "Laura", "Garcia" },
                    { 11, 36, "Daniel", "Robinson" },
                    { 12, 43, "Lisa", "Miller" },
                    { 13, 44, "William", "Hernandez" },
                    { 14, 33, "Patricia", "Lopez" },
                    { 15, 39, "Richard", "Lewis" },
                    { 16, 34, "Karen", "Clark" },
                    { 17, 32, "Jason", "Young" },
                    { 18, 20, "Adam", "Lin" },
                    { 19, 54, "Lo", "La" },
                    { 20, 22, "Tom", "Voldoende" },
                    { 21, 34, "Rico", "Sof" },
                    { 22, 23, "Gert", "Jan" },
                    { 23, 23, "Dit", "Vak" },
                    { 24, 23, "Is", "Leuk" },
                    { 25, 45, "Hans", "Kazan" },
                    { 26, 54, "Mohammed", "Salah" },
                    { 27, 65, "Han", "fee" },
                    { 28, 43, "DA", "effe" },
                    { 29, 65, "da", "vdfv" },
                    { 30, 64, "dw", "t4" },
                    { 31, 34, "Jop", "rt" },
                    { 32, 32, "wceadweas", "trer" },
                    { 33, 32, "ef", "gh" },
                    { 34, 43, "feef", "hdfg" },
                    { 35, 32, "ef", "gh" },
                    { 36, 43, "feef", "hdfg" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "FeaturesList", "LandLordId", "NumberOfGuests", "PricePerDay", "Rooms", "Subtitle", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "De camping ligt verscholen achter de boerderij in de polder. Geniet van de rust en ruimte op De Boerenhoeve, waar de natuur je omringt en de frisse lucht je verwelkomt. Onze comfortabele appartementen bieden een thuis weg van huis, met moderne voorzieningen en een sfeervolle inrichting. Ontspan op het terras en bewonder het prachtige uitzicht op de omringende weilanden. Of verken de nabijgelegen wandel- en fietspaden voor een onvergetelijke ervaring in de natuur. We heten je van harte welkom op De Boerenhoeve!", "[2,3]", 1, 4, 100f, 2, "Lekker veel ruimte", "De Boerenhoeve", 0 },
                    { 2, "Ervaar de ultieme vakantie aan de kust in ons Zeezicht Appartement. Geniet van adembenemende uitzichten op de zee vanuit je ruime en comfortabele accommodatie. Ontspan op het balkon en luister naar het rustgevende geluid van de golven. Het appartement is smaakvol ingericht en voorzien van moderne voorzieningen. Verken de nabijgelegen stranden, restaurants en bezienswaardigheden voor een onvergetelijke vakantie aan zee.", "[2,3,4]", 2, 6, 150f, 3, "Prachtig uitzicht op de zee", "Zeezicht Appartement", 0 },
                    { 3, "Ontsnap aan de drukte en omarm de natuur in ons Groene Oase Chalet. Dit charmante chalet is omgeven door weelderig groen en biedt een rustige toevluchtsoord voor natuurliefhebbers. Het chalet is voorzien van alle gemakken en beschikt over een eigen tuin waar je kunt genieten van de flora en fauna. Verken de wandelpaden, observeer vogels en kom helemaal tot rust in deze groene oase.", "[1,5]", 1, 2, 120f, 1, "Omgeven door natuur", "Groene Oase Chalet", 2 },
                    { 4, "Verblijf in stijl in ons Historisch Stadsappartement, gelegen in het hart van de oude stad. Het appartement combineert moderne luxe met historische charme en biedt een unieke ervaring. Wandel door smalle steegjes, ontdek historische bezienswaardigheden en proef lokale gerechten in de nabijgelegen restaurants. Het appartement is smaakvol ingericht en voorzien van alle moderne gemakken voor een comfortabel en cultureel verblijf.", "[2,3]", 1, 4, 130f, 2, "Verken de oude stad", "Historisch Stadsappartement", 0 },
                    { 5, "Escape to this charming cottage nestled by the serene lake. Enjoy the rustic charm and peaceful surroundings with stunning lake views. The cottage features a cozy interior with a fireplace, perfect for romantic getaways or family vacations. Explore nearby hiking trails, go fishing, or simply unwind on the private dock. This retreat promises a rejuvenating experience in nature's embrace.", "[1,2]", 2, 4, 110f, 2, "Tranquil waterside retreat", "Rustic Cottage by the Lake", 1 },
                    { 6, "Live in style in this sleek urban loft situated in the heart of downtown. Experience contemporary living with high ceilings, industrial-chic decor, and panoramic city views. The loft is fully equipped with state-of-the-art amenities and is ideal for professionals or urban explorers seeking convenience and luxury. Step outside to trendy cafes, art galleries, and nightlife hotspots for a vibrant city experience.", "[2,3]", 3, 2, 180f, 1, "Modern city living", "Urban Loft in Downtown", 0 },
                    { 7, "Embrace tranquility at this secluded mountain retreat, surrounded by majestic peaks and lush forests. The cabin offers a cozy atmosphere with wood-panelled interiors, a crackling fireplace, and breathtaking mountain views from the deck. Hike scenic trails, spot wildlife, or simply relax in the hot tub under the starlit sky. This retreat is perfect for nature enthusiasts and those seeking a peaceful mountain escape.", "[1,5]", 2, 6, 200f, 3, "A sanctuary in the mountains", "Secluded Mountain Retreat", 2 },
                    { 8, "Indulge in luxury at this beachfront villa boasting panoramic ocean views and direct beach access. The villa features spacious rooms, elegant decor, and a private pool overlooking the sea. Pamper yourself with in-villa spa treatments or dine al fresco on the terrace with sunset views. Explore pristine beaches, water sports, and local seafood cuisine for a luxurious coastal retreat.", "[2,4]", 1, 8, 500f, 4, "Exclusive oceanfront living", "Luxury Beachfront Villa", 5 },
                    { 9, "Step back in time at this historic manor house, offering grandeur and elegance amidst sprawling gardens and ancient architecture. The manor features opulent rooms, antique furnishings, and impeccable service for a luxurious stay. Stroll through manicured gardens, enjoy afternoon tea in the drawing room, or explore nearby historic landmarks. This estate promises a refined retreat steeped in history.", "[2,5]", 3, 20, 1000f, 10, "Elegant heritage accommodation", "Historic Manor House", 4 },
                    { 10, "Escape to this cozy ski chalet nestled in a picturesque alpine village. The chalet features timber interiors, a roaring fireplace, and stunning mountain views from the balcony. Ski-in, ski-out access makes it perfect for winter sports enthusiasts, while summer visitors can hike scenic trails or relax in the sauna. Enjoy après-ski in the village or unwind with hot chocolate by the fire.", "[2,3,4]", 2, 6, 250f, 3, "Winter wonderland getaway", "Cozy Ski Chalet", 2 },
                    { 11, "Experience country charm at this quaint bed and breakfast nestled in rolling hills. The B&B offers cozy rooms with floral decor, homemade breakfasts, and a warm, welcoming atmosphere. Explore nearby vineyards, go horseback riding, or simply relax in the garden with a book. This retreat is ideal for couples seeking a peaceful rural escape.", "[5]", 1, 10, 150f, 5, "Charming bed and breakfast", "Quaint Countryside B&B", 5 },
                    { 12, "Enjoy unparalleled luxury in this lakeview penthouse suite boasting floor-to-ceiling windows and a private terrace overlooking the water. The suite features contemporary design, high-end amenities, and exclusive access to a rooftop pool and spa. Indulge in gourmet dining, yacht cruises, or lakeside walks for a sophisticated lakeside retreat.", "[2,3,4]", 3, 4, 350f, 2, "Luxury lakeside living", "Lakeview Penthouse Suite", 0 },
                    { 13, "Immerse yourself in nature at this eco-friendly treehouse retreat hidden deep in the forest. The treehouse offers a unique stay with sustainable design, panoramic forest views, and tranquil surroundings. Disconnect from technology, hike through ancient woods, or stargaze from the treehouse deck. This retreat is perfect for eco-conscious travelers seeking a back-to-nature experience.", "[1]", 2, 2, 80f, 1, "Off-grid wilderness escape", "Eco-Friendly Treehouse", 1 },
                    { 14, "Experience modern living in this sleek city studio located in a bustling downtown district. The studio features minimalist decor, a compact kitchenette, and access to a rooftop garden with city skyline views. Explore nearby cafes, shops, and cultural attractions or retreat to your stylish urban oasis after a day of city exploration.", "[2]", 1, 2, 100f, 1, "Convenient urban living", "Modern City Studio", 3 },
                    { 15, "Escape to this charming log cabin nestled on the shores of a tranquil lake. The cabin features rustic wood interiors, a stone fireplace, and a private dock for fishing and boating. Enjoy serene lake views from the porch swing or explore nearby hiking trails and wildlife spotting opportunities. This cabin promises a cozy retreat in nature's embrace.", "[2,1]", 3, 4, 150f, 2, "Rustic lakeside retreat", "Lakeside Log Cabin", 2 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LandLordId", "LocationId", "Url" },
                values: new object[,]
                {
                    { 1, true, 1, 1, "https://watismijnhuiswaard.com/wp-content/uploads/2021/06/Boerderij-1024x512.jpg" },
                    { 2, true, 2, 2, "https://www.egmondverhuur.nl/sites/egmondverhuur/files/styles/slide/public/images/appartementen-met-zeezicht_0.jpg?itok=iAWaBQd2" },
                    { 3, true, 3, 6, "https://images.unsplash.com/photo-1523217582562-09d0def993a6?q=80&w=2080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 4, true, 4, 7, "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?q=80&w=2075&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 5, true, 5, 8, "https://images.unsplash.com/photo-1583608205776-bfd35f0d9f83?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 6, true, 6, 9, "https://generatorfun.com/code/uploads/Random-House-image-15.jpg" },
                    { 7, true, 7, 10, "https://generatorfun.com/code/uploads/Random-House-image-1.jpg" },
                    { 8, true, 8, 11, "https://generatorfun.com/code/uploads/Random-House-image-13.jpg" },
                    { 9, true, 9, 12, "https://generatorfun.com/code/uploads/Random-House-image-13.jpg" },
                    { 10, true, 10, 13, "https://generatorfun.com/code/uploads/Random-House-image-10.jpg" },
                    { 11, true, 11, 14, "https://generatorfun.com/code/uploads/Random-House-image-19.jpg" },
                    { 12, true, 12, 15, "https://generatorfun.com/code/uploads/Random-House-image-9.jpg" },
                    { 16, true, 16, 3, "https://generatorfun.com/code/uploads/Random-House-image-5.jpg" },
                    { 17, true, 17, 4, "https://generatorfun.com/code/uploads/Random-House-image-10.jpg" },
                    { 18, true, 18, 5, "https://generatorfun.com/code/uploads/Random-House-image-19.jpg" },
                    { 19, false, 19, 1, "https://generatorfun.com/code/uploads/Random-House-image-9.jpg" },
                    { 20, false, 20, 2, "https://generatorfun.com/code/uploads/Random-House-image-5.jpg" },
                    { 21, false, 21, 3, "https://generatorfun.com/code/uploads/Random-House-image-10.jpg" },
                    { 22, false, 22, 4, "https://generatorfun.com/code/uploads/Random-House-image-19.jpg" },
                    { 23, false, 23, 5, "https://generatorfun.com/code/uploads/Random-House-image-9.jpg" },
                    { 24, false, 24, 6, "https://generatorfun.com/code/uploads/Random-House-image-5.jpg" },
                    { 25, false, 25, 7, "https://generatorfun.com/code/uploads/Random-House-image-10.jpg" },
                    { 26, false, 26, 8, "https://generatorfun.com/code/uploads/Random-House-image-19.jpg" },
                    { 27, false, 27, 9, "https://generatorfun.com/code/uploads/Random-House-image-9.jpg" },
                    { 28, false, 28, 10, "https://generatorfun.com/code/uploads/Random-House-image-5.jpg" },
                    { 29, false, 29, 11, "https://generatorfun.com/code/uploads/Random-House-image-10.jpg" },
                    { 30, false, 30, 12, "https://generatorfun.com/code/uploads/Random-House-image-19.jpg" },
                    { 31, false, 31, 13, "https://generatorfun.com/code/uploads/Random-House-image-9.jpg" },
                    { 32, false, 32, 14, "https://generatorfun.com/code/uploads/Random-House-image-5.jpg" },
                    { 33, false, 33, 15, "https://generatorfun.com/code/uploads/Random-House-image-10.jpg" },
                    { 34, false, 34, 1, "https://generatorfun.com/code/uploads/Random-House-image-19.jpg" },
                    { 35, false, 35, 2, "https://generatorfun.com/code/uploads/Random-House-image-9.jpg" },
                    { 36, false, 36, 3, "https://generatorfun.com/code/uploads/Random-House-image-5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CostumerId", "Discount", "EndDate", "LocationId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 10f, new DateTime(2024, 6, 27, 23, 0, 27, 424, DateTimeKind.Local).AddTicks(9544), 1, new DateTime(2024, 6, 24, 23, 0, 27, 424, DateTimeKind.Local).AddTicks(9504) },
                    { 2, 2, 5f, new DateTime(2024, 6, 29, 23, 0, 27, 424, DateTimeKind.Local).AddTicks(9551), 2, new DateTime(2024, 6, 24, 23, 0, 27, 424, DateTimeKind.Local).AddTicks(9549) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_LandLordId",
                table: "Images",
                column: "LandLordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_LocationId",
                table: "Images",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LandLordId",
                table: "Locations",
                column: "LandLordId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CostumerId",
                table: "Reservations",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "LandLords");
        }
    }
}
