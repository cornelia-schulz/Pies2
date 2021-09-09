using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pies.API.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PieFlavourTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlavourType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieFlavourTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PieReviewStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieReviewStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PieTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FlavourTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PieTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pies_PieTypes_PieTypeId",
                        column: x => x.PieTypeId,
                        principalTable: "PieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PieReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PieReviews_Pies_PieId",
                        column: x => x.PieId,
                        principalTable: "Pies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "County", "Latitude", "Longitude", "Street" },
                values: new object[,]
                {
                    { new Guid("f8f97e88-10f8-11ec-82a8-0242ac130003"), "Christchurch", "New Zealand", "Canterbury", -43.549126911758606, 172.62206744255727, "290 Selwyn St" },
                    { new Guid("f8f9814e-10f8-11ec-82a8-0242ac130003"), "Christchurch", "New Zealand", "Canterbury", -43.533927237712405, 172.63397647139195, "Riverside Market" },
                    { new Guid("f8f984fa-10f8-11ec-82a8-0242ac130003"), "Christchurch", "New Zealand", "Canterbury", -43.549126911758606, 172.62206744255727, "409 Harewood Rd" },
                    { new Guid("f8f97e88-10f8-11ec-82a8-0442ac130003"), "Auckland", "New Zealand", "Auckland", -36.724402083233649, 174.69367782327271, "247 Dairy Flat Highway" }
                });

            migrationBuilder.InsertData(
                table: "PieFlavourTypes",
                columns: new[] { "Id", "FlavourType" },
                values: new object[,]
                {
                    { 1, "Gourmet" },
                    { 2, "Sweet" },
                    { 3, "Savoury" }
                });

            migrationBuilder.InsertData(
                table: "PieReviewStatuses",
                columns: new[] { "Id", "ReviewStatus" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Reviewed" },
                    { 3, "Removed" }
                });

            migrationBuilder.InsertData(
                table: "PieTypes",
                columns: new[] { "Id", "FlavourTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), 1, "Pork & Apple" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), 3, "Mexican" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), 2, "Berry" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), 1, "Mushroom" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), 3, "Steak" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), 3, "Butter Chicken" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), 2, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "DateCreated", "Description", "LocationId", "Name", "ReviewStatusId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f8f98446-10f8-11ec-82a8-0242ac130003"), new DateTimeOffset(new DateTime(2021, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)), "Award Winning Danish-European Style Bakery, Copenhagen serves a delicious selection breads and treats, at the café and online.", new Guid("f8f984fa-10f8-11ec-82a8-0242ac130003"), "Copenhagen Bakery", new Guid("f8f985ae-10f8-11ec-82a8-0242ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") },
                    { new Guid("f8f978b6-10f8-11ec-82a8-0242ac130003"), new DateTimeOffset(new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)), "Delicious, homemade daily Pies, Slices, Cakes, Savories and Sandwiches", new Guid("f8f97e88-10f8-11ec-82a8-0242ac130003"), "Pies and Coffee", new Guid("f8f97fb4-10f8-11ec-82a8-0242ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") },
                    { new Guid("f8f98086-10f8-11ec-82a8-0242ac130003"), new DateTimeOffset(new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)), "Family patisserie. Pastries, pasties, entremets, choux, tarts, cakey stuff.", new Guid("f8f9814e-10f8-11ec-82a8-0242ac130003"), "The great pastry shop", new Guid("f8f9820c-10f8-11ec-82a8-0242ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") },
                    { new Guid("f8f98662-10f8-11ec-82a8-0242ac130003"), new DateTimeOffset(new DateTime(2017, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0)), "Pioneer Pie Co is a family run business dedicated to producing Pies of the highest quality.", new Guid("f8f97e88-10f8-11ec-82a8-0442ac130003"), "Pioneer Pies", new Guid("f8f97fb4-10f8-11ec-82a8-0422ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") }
                });

            migrationBuilder.InsertData(
                table: "Pies",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "Name", "PieTypeId", "ShopId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new DateTimeOffset(new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)), null, "Mushroom Pie", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("f8f98662-10f8-11ec-82a8-0242ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new DateTimeOffset(new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)), null, "Butter Chicken Pie", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("f8f98446-10f8-11ec-82a8-0242ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new DateTimeOffset(new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)), null, "Steak Pie", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("f8f98086-10f8-11ec-82a8-0242ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new DateTimeOffset(new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0)), null, "Apple Pie", new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new Guid("f8f978b6-10f8-11ec-82a8-0242ac130003"), new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") }
                });

            migrationBuilder.InsertData(
                table: "PieReviews",
                columns: new[] { "Id", "DateCreated", "Description", "PieId", "Rating", "UserId" },
                values: new object[] { new Guid("40ff5488-fdab-45c7-bc3a-14302d59869a"), new DateTimeOffset(new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0)), "What a great pie", new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 5, new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee") });

            migrationBuilder.InsertData(
                table: "PieReviews",
                columns: new[] { "Id", "DateCreated", "Description", "PieId", "Rating", "UserId" },
                values: new object[] { new Guid("40ff5488-fdab-45e7-bc3a-14302d59869a"), new DateTimeOffset(new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)), "Superb", new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 5, new Guid("d8663e5e-7486-4f23-8739-6e0de1bea7ee") });

            migrationBuilder.CreateIndex(
                name: "IX_PieReviews_PieId",
                table: "PieReviews",
                column: "PieId");

            migrationBuilder.CreateIndex(
                name: "IX_Pies_PieTypeId",
                table: "Pies",
                column: "PieTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PieFlavourTypes");

            migrationBuilder.DropTable(
                name: "PieReviews");

            migrationBuilder.DropTable(
                name: "PieReviewStatuses");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Pies");

            migrationBuilder.DropTable(
                name: "PieTypes");
        }
    }
}
