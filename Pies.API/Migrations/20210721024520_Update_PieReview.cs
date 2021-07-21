using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pies.API.Migrations
{
    public partial class Update_PieReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PieReviews",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45c7-bc3a-14302d59869a"),
                column: "PieId",
                value: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.UpdateData(
                table: "PieReviews",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45e7-bc3a-14302d59869a"),
                column: "PieId",
                value: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PieReviews",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45c7-bc3a-14302d59869a"),
                column: "PieId",
                value: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.UpdateData(
                table: "PieReviews",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45e7-bc3a-14302d59869a"),
                column: "PieId",
                value: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));
        }
    }
}
