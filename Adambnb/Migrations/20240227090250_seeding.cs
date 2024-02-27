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
                    { 1, "Description1", "[2,3]", 1, 4, 100f, 2, "Subtitle1", "Location1", 0 },
                    { 2, "Description2", "[0,1]", 2, 6, 150f, 3, "Subtitle2", "Location2", 5 }
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
                    { 1, 1, 10f, new DateTime(2024, 3, 1, 10, 2, 49, 651, DateTimeKind.Local).AddTicks(582), 1, new DateTime(2024, 2, 27, 10, 2, 49, 651, DateTimeKind.Local).AddTicks(509) },
                    { 2, 2, 5f, new DateTime(2024, 3, 3, 10, 2, 49, 651, DateTimeKind.Local).AddTicks(591), 2, new DateTime(2024, 2, 27, 10, 2, 49, 651, DateTimeKind.Local).AddTicks(589) }
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
