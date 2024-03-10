using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Adambnb.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 2, 40, "Landlord2", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "FeaturesList", "LandLordId", "NumberOfGuests", "PricePerDay", "Rooms", "Subtitle", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "De camping ligt verscholen achter de boerderij in de polder. Geniet van de rust en ruimte op De Boerenhoeve, waar de natuur je omringt en de frisse lucht je verwelkomt. Onze comfortabele appartementen bieden een thuis weg van huis, met moderne voorzieningen en een sfeervolle inrichting. Ontspan op het terras en bewonder het prachtige uitzicht op de omringende weilanden. Of verken de nabijgelegen wandel- en fietspaden voor een onvergetelijke ervaring in de natuur. We heten je van harte welkom op De Boerenhoeve!", "[2,3]", 1, 4, 100f, 2, "Lekker veel ruimte", "De Boerenhoeve", 0 },
                    { 2, "Ervaar de ultieme vakantie aan de kust in ons Zeezicht Appartement. Geniet van adembenemende uitzichten op de zee vanuit je ruime en comfortabele accommodatie. Ontspan op het balkon en luister naar het rustgevende geluid van de golven. Het appartement is smaakvol ingericht en voorzien van moderne voorzieningen. Verken de nabijgelegen stranden, restaurants en bezienswaardigheden voor een onvergetelijke vakantie aan zee.", "[2,3,4]", 2, 6, 150f, 3, "Prachtig uitzicht op de zee", "Zeezicht Appartement", 0 },
                    { 3, "Ontsnap aan de drukte en omarm de natuur in ons Groene Oase Chalet. Dit charmante chalet is omgeven door weelderig groen en biedt een rustige toevluchtsoord voor natuurliefhebbers. Het chalet is voorzien van alle gemakken en beschikt over een eigen tuin waar je kunt genieten van de flora en fauna. Verken de wandelpaden, observeer vogels en kom helemaal tot rust in deze groene oase.", "[1,5]", 1, 2, 120f, 1, "Omgeven door natuur", "Groene Oase Chalet", 2 },
                    { 4, "Verblijf in stijl in ons Historisch Stadsappartement, gelegen in het hart van de oude stad. Het appartement combineert moderne luxe met historische charme en biedt een unieke ervaring. Wandel door smalle steegjes, ontdek historische bezienswaardigheden en proef lokale gerechten in de nabijgelegen restaurants. Het appartement is smaakvol ingericht en voorzien van alle moderne gemakken voor een comfortabel en cultureel verblijf.", "[2,3]", 1, 4, 130f, 2, "Verken de oude stad", "Historisch Stadsappartement", 0 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LandLordId", "LocationId", "Url" },
                values: new object[,]
                {
                    { 1, true, 1, 1, "image1.jpg" },
                    { 2, true, 2, 2, "image2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CostumerId", "Discount", "EndDate", "LocationId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 10f, new DateTime(2024, 3, 2, 12, 0, 26, 363, DateTimeKind.Local).AddTicks(7646), 1, new DateTime(2024, 2, 28, 12, 0, 26, 363, DateTimeKind.Local).AddTicks(7584) },
                    { 2, 2, 5f, new DateTime(2024, 3, 4, 12, 0, 26, 363, DateTimeKind.Local).AddTicks(7662), 2, new DateTime(2024, 2, 28, 12, 0, 26, 363, DateTimeKind.Local).AddTicks(7660) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Costumers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LandLords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LandLords",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
