using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeddingdatatodifficultiesandRegionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("540f0e75-ffc1-42b2-bda0-d8bac6ca0367"), "Hard" },
                    { new Guid("7b2a2ef9-4f0f-4685-91b8-00b27251c609"), "Medium" },
                    { new Guid("d09f585f-8792-49f5-9401-d8a03d1dc379"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3d0e7a41-91f1-4aea-99f5-b7182d858c87"), "AKL", "Aukland", "https://tse4.mm.bing.net/th?id=OIP.GbvnlvwTocdjfHI6sCfzcgHaE8&pid=Api&P=0&h=180.jpg" },
                    { new Guid("b05d04d2-2f6e-43d2-bbcd-0ec2db15bdc0"), "WDL", "Welligton", "https://mediaim.expedia.com/destination/1/e34399c39d76167d8fead4e03a9efd2f.jpg" },
                    { new Guid("b6f3a6f0-5226-4ff9-b2a0-14fb89f749cb"), "STL", "SouthLand", "http://www.lasty.com.pl/region/large/1/RAUNZ/region-auckland.JPG" },
                    { new Guid("cc654047-0e86-4f39-95fd-433d794192ae"), "BPL", "Bay Of Plenty", "https://tse4.mm.bing.net/th?id=OIP.4OOoGfJ50A-r_b5MWsgi0gHaE8&pid=Api&P=0&h=180.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("540f0e75-ffc1-42b2-bda0-d8bac6ca0367"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7b2a2ef9-4f0f-4685-91b8-00b27251c609"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d09f585f-8792-49f5-9401-d8a03d1dc379"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3d0e7a41-91f1-4aea-99f5-b7182d858c87"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b05d04d2-2f6e-43d2-bbcd-0ec2db15bdc0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b6f3a6f0-5226-4ff9-b2a0-14fb89f749cb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cc654047-0e86-4f39-95fd-433d794192ae"));
        }
    }
}
