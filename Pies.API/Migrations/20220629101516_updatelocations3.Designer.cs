﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pies.API.DbContexts;

namespace Pies.API.Migrations
{
    [DbContext(typeof(PiesContext))]
    [Migration("20220629101516_updatelocations3")]
    partial class updatelocations3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pies.API.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f8f97e88-10f8-11ec-82a8-0242ac130003"),
                            City = "Christchurch",
                            Country = "New Zealand",
                            County = "Canterbury",
                            Latitude = -43.549126911758606,
                            Longitude = 172.62206744255727,
                            Street = "290 Selwyn St"
                        },
                        new
                        {
                            Id = new Guid("f8f9814e-10f8-11ec-82a8-0242ac130003"),
                            City = "Christchurch",
                            Country = "New Zealand",
                            County = "Canterbury",
                            Latitude = -43.533927237712405,
                            Longitude = 172.63397647139195,
                            Street = "Riverside Market"
                        },
                        new
                        {
                            Id = new Guid("f8f984fa-10f8-11ec-82a8-0242ac130003"),
                            City = "Christchurch",
                            Country = "New Zealand",
                            County = "Canterbury",
                            Latitude = -43.484311485809485,
                            Longitude = 172.57846588303863,
                            Street = "409 Harewood Rd"
                        },
                        new
                        {
                            Id = new Guid("f8f97e88-10f8-11ec-82a8-0442ac130003"),
                            City = "Auckland",
                            Country = "New Zealand",
                            County = "Auckland",
                            Latitude = -36.724023689201132,
                            Longitude = 174.69388166860529,
                            Street = "247 Dairy Flat Highway"
                        });
                });

            modelBuilder.Entity("Pies.API.Entities.Pie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateDeleted")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("PieTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PieTypeId");

                    b.ToTable("Pies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            DateCreated = new DateTimeOffset(new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)),
                            Name = "Mushroom Pie",
                            PieTypeId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ShopId = new Guid("f8f98662-10f8-11ec-82a8-0242ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            DateCreated = new DateTimeOffset(new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)),
                            Name = "Butter Chicken Pie",
                            PieTypeId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ShopId = new Guid("f8f98446-10f8-11ec-82a8-0242ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        },
                        new
                        {
                            Id = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            DateCreated = new DateTimeOffset(new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)),
                            Name = "Steak Pie",
                            PieTypeId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            ShopId = new Guid("f8f98086-10f8-11ec-82a8-0242ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            DateCreated = new DateTimeOffset(new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0)),
                            Name = "Apple Pie",
                            PieTypeId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            ShopId = new Guid("f8f978b6-10f8-11ec-82a8-0242ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        });
                });

            modelBuilder.Entity("Pies.API.Entities.PieFlavourType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlavourType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PieFlavourTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FlavourType = "Gourmet"
                        },
                        new
                        {
                            Id = 2,
                            FlavourType = "Sweet"
                        },
                        new
                        {
                            Id = 3,
                            FlavourType = "Savoury"
                        });
                });

            modelBuilder.Entity("Pies.API.Entities.PieReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<Guid>("PieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PieId");

                    b.ToTable("PieReviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45c7-bc3a-14302d59869a"),
                            DateCreated = new DateTimeOffset(new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0)),
                            Description = "What a great pie",
                            PieId = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Rating = 5,
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45e7-bc3a-14302d59869a"),
                            DateCreated = new DateTimeOffset(new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)),
                            Description = "Superb",
                            PieId = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Rating = 5,
                            UserId = new Guid("d8663e5e-7486-4f23-8739-6e0de1bea7ee")
                        });
                });

            modelBuilder.Entity("Pies.API.Entities.PieReviewStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReviewStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PieReviewStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ReviewStatus = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            ReviewStatus = "Reviewed"
                        },
                        new
                        {
                            Id = 3,
                            ReviewStatus = "Removed"
                        });
                });

            modelBuilder.Entity("Pies.API.Entities.PieType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FlavourTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PieTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            FlavourTypeId = 1,
                            Name = "Mushroom"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            FlavourTypeId = 3,
                            Name = "Butter Chicken"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            FlavourTypeId = 3,
                            Name = "Steak"
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            FlavourTypeId = 2,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            FlavourTypeId = 2,
                            Name = "Berry"
                        },
                        new
                        {
                            Id = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            FlavourTypeId = 3,
                            Name = "Mexican"
                        },
                        new
                        {
                            Id = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            FlavourTypeId = 1,
                            Name = "Pork & Apple"
                        });
                });

            modelBuilder.Entity("Pies.API.Entities.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReviewStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f8f978b6-10f8-11ec-82a8-0242ac130003"),
                            DateCreated = new DateTimeOffset(new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)),
                            Description = "Delicious, homemade daily Pies, Slices, Cakes, Savories and Sandwiches",
                            LocationId = new Guid("f8f97e88-10f8-11ec-82a8-0242ac130003"),
                            Name = "Pies and Coffee",
                            ReviewStatusId = new Guid("f8f97fb4-10f8-11ec-82a8-0242ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        },
                        new
                        {
                            Id = new Guid("f8f98086-10f8-11ec-82a8-0242ac130003"),
                            DateCreated = new DateTimeOffset(new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)),
                            Description = "Family patisserie. Pastries, pasties, entremets, choux, tarts, cakey stuff.",
                            LocationId = new Guid("f8f9814e-10f8-11ec-82a8-0242ac130003"),
                            Name = "The great pastry shop",
                            ReviewStatusId = new Guid("f8f9820c-10f8-11ec-82a8-0242ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        },
                        new
                        {
                            Id = new Guid("f8f98446-10f8-11ec-82a8-0242ac130003"),
                            DateCreated = new DateTimeOffset(new DateTime(2021, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0)),
                            Description = "Award Winning Danish-European Style Bakery, Copenhagen serves a delicious selection breads and treats, at the café and online.",
                            LocationId = new Guid("f8f984fa-10f8-11ec-82a8-0242ac130003"),
                            Name = "Copenhagen Bakery",
                            ReviewStatusId = new Guid("f8f985ae-10f8-11ec-82a8-0242ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        },
                        new
                        {
                            Id = new Guid("f8f98662-10f8-11ec-82a8-0242ac130003"),
                            DateCreated = new DateTimeOffset(new DateTime(2017, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0)),
                            Description = "Pioneer Pie Co is a family run business dedicated to producing Pies of the highest quality.",
                            LocationId = new Guid("f8f97e88-10f8-11ec-82a8-0442ac130003"),
                            Name = "Pioneer Pies",
                            ReviewStatusId = new Guid("f8f97fb4-10f8-11ec-82a8-0422ac130003"),
                            UserId = new Guid("d8663e5e-7486-4f81-8739-6e0de1bea7ee")
                        });
                });

            modelBuilder.Entity("Pies.API.Entities.Pie", b =>
                {
                    b.HasOne("Pies.API.Entities.PieType", "PieType")
                        .WithMany()
                        .HasForeignKey("PieTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PieType");
                });

            modelBuilder.Entity("Pies.API.Entities.PieReview", b =>
                {
                    b.HasOne("Pies.API.Entities.Pie", null)
                        .WithMany("PieReviews")
                        .HasForeignKey("PieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pies.API.Entities.Shop", b =>
                {
                    b.HasOne("Pies.API.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Pies.API.Entities.Pie", b =>
                {
                    b.Navigation("PieReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
