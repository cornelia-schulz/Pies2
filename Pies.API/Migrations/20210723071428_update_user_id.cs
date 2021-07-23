using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pies.API.Migrations
{
    public partial class update_user_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Pies",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                column: "UserId",
                value: new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                column: "UserId",
                value: new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                column: "UserId",
                value: new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                column: "UserId",
                value: new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Pies",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                column: "UserId",
                value: 1);
        }
    }
}
