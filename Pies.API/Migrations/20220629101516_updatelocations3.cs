using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pies.API.Migrations
{
    public partial class updatelocations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("f8f97e88-10f8-11ec-82a8-0442ac130003"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { -36.724023689201132, 174.69388166860529 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("f8f97e88-10f8-11ec-82a8-0442ac130003"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { -36.724402083233649, 174.69367782327271 });
        }
    }
}
