using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pies.API.Migrations
{
    public partial class updatelocations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("f8f984fa-10f8-11ec-82a8-0242ac130003"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { -43.484311485809485, 172.57846588303863 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("f8f984fa-10f8-11ec-82a8-0242ac130003"),
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { -43.549126911758606, 172.62206744255727 });
        }
    }
}
