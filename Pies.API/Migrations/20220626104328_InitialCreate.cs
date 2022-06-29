using Microsoft.EntityFrameworkCore.Migrations;

namespace Pies.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shops_LocationId",
                table: "Shops",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Locations_LocationId",
                table: "Shops",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Locations_LocationId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_LocationId",
                table: "Shops");
        }
    }
}
