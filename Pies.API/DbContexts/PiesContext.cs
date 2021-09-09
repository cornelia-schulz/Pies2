using Pies.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Pies.API.DbContexts
{
    public class PiesContext : DbContext
    {
        public PiesContext(DbContextOptions<PiesContext> options)
           : base(options)
        {
        }

        public DbSet<PieType> PieTypes { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<PieFlavourType> PieFlavourTypes { get; set; }
        public DbSet<PieReviewStatus> PieReviewStatuses { get; set; }
        public DbSet<PieReview> PieReviews { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<PieType>().HasData(
                new PieType()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Mushroom",
                    FlavourTypeId = 1
                },
                new PieType()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Butter Chicken",
                    FlavourTypeId = 3
                },
                new PieType()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Steak",
                    FlavourTypeId = 3
                },
                new PieType()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Name = "Apple",
                    FlavourTypeId = 2
                },
                new PieType()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Name = "Berry",
                    FlavourTypeId = 2
                },
                new PieType()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    Name = "Mexican",
                    FlavourTypeId = 3
                },
                new PieType()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    Name = "Pork & Apple",
                    FlavourTypeId = 1
                }
                );

            modelBuilder.Entity<Pie>().HasData(
               new Pie
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   PieTypeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   DateCreated = new DateTime(2020, 7, 23),
                   Name = "Mushroom Pie",
                   UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                   ShopId = Guid.Parse("f8f98662-10f8-11ec-82a8-0242ac130003")
               },
               new Pie
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   PieTypeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   DateCreated = new DateTime(2021, 8, 23),
                   Name = "Butter Chicken Pie",
                   UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                   ShopId = Guid.Parse("f8f98446-10f8-11ec-82a8-0242ac130003")
               },
               new Pie
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   PieTypeId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   DateCreated = new DateTime(2019, 9, 26),
                   Name = "Steak Pie",
                   UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                   ShopId = Guid.Parse("f8f98086-10f8-11ec-82a8-0242ac130003")
               },
               new Pie
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   PieTypeId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   DateCreated = new DateTime(2020, 3, 2),
                   Name = "Apple Pie",
                   UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                   ShopId = Guid.Parse("f8f978b6-10f8-11ec-82a8-0242ac130003")
               }
               );

            modelBuilder.Entity<PieFlavourType>().HasData(
               new PieFlavourType()
               {
                   Id = 1,
                   FlavourType = "Gourmet"
               },
               new PieFlavourType()
               {
                   Id = 2,
                   FlavourType = "Sweet"
               },
               new PieFlavourType()
               {
                   Id = 3,
                   FlavourType = "Savoury",
               }
               );

            modelBuilder.Entity<PieReviewStatus>().HasData(
                new PieReviewStatus()
                {
                    Id = 1,
                    ReviewStatus = "Pending"
                },
                new PieReviewStatus()
                {
                    Id = 2,
                    ReviewStatus = "Reviewed"
                },
                new PieReviewStatus()
                {
                    Id = 3,
                    ReviewStatus = "Removed"
                }
                );

            modelBuilder.Entity<PieReview>().HasData(
                new PieReview()
                {
                    Id = Guid.Parse("40ff5488-fdab-45c7-bc3a-14302d59869a"),
                    PieId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    DateCreated = new DateTime(2020, 3, 2),
                    UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                    Description = "What a great pie",
                    Rating = 5
                },
                new PieReview()
                {
                    Id = Guid.Parse("40ff5488-fdab-45e7-bc3a-14302d59869a"),
                    PieId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    DateCreated = new DateTime(2020, 7, 20),
                    UserId = Guid.Parse("d8663e5e-7486-4f23-8739-6e0de1bea7ee"),
                    Description = "Superb",
                    Rating = 5
                }
                );

            modelBuilder.Entity<Shop>().HasData(
                new Shop()
                {
                    Id = Guid.Parse("f8f978b6-10f8-11ec-82a8-0242ac130003"),
                    LocationId = Guid.Parse("f8f97e88-10f8-11ec-82a8-0242ac130003"),
                    Name = "Pies and Coffee",
                    UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                    DateCreated = new DateTime(2020, 6, 2),
                    Description = "Delicious, homemade daily Pies, Slices, Cakes, Savories and Sandwiches",
                    ReviewStatusId = Guid.Parse("f8f97fb4-10f8-11ec-82a8-0242ac130003")
                },
                new Shop()
                {
                    Id = Guid.Parse("f8f98086-10f8-11ec-82a8-0242ac130003"),
                    LocationId = Guid.Parse("f8f9814e-10f8-11ec-82a8-0242ac130003"),
                    Name = "The great pastry shop",
                    UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                    DateCreated = new DateTime(2019, 7, 12),
                    Description = "Family patisserie. Pastries, pasties, entremets, choux, tarts, cakey stuff.",
                    ReviewStatusId = Guid.Parse("f8f9820c-10f8-11ec-82a8-0242ac130003")
                },
                new Shop()
                {
                    Id = Guid.Parse("f8f98446-10f8-11ec-82a8-0242ac130003"),
                    LocationId = Guid.Parse("f8f984fa-10f8-11ec-82a8-0242ac130003"),
                    Name = "Copenhagen Bakery",
                    UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                    DateCreated = new DateTime(2021, 4, 8),
                    Description = "Award Winning Danish-European Style Bakery, Copenhagen serves a delicious selection breads and treats, at the café and online.",
                    ReviewStatusId = Guid.Parse("f8f985ae-10f8-11ec-82a8-0242ac130003")
                },
                new Shop()
                {
                    Id = Guid.Parse("f8f98662-10f8-11ec-82a8-0242ac130003"),
                    LocationId = Guid.Parse("f8f97e88-10f8-11ec-82a8-0442ac130003"),
                    Name = "Pioneer Pies",
                    UserId = Guid.Parse("d8663e5e-7486-4f81-8739-6e0de1bea7ee"),
                    DateCreated = new DateTime(2017, 12, 6),
                    Description = "Pioneer Pie Co is a family run business dedicated to producing Pies of the highest quality.",
                    ReviewStatusId = Guid.Parse("f8f97fb4-10f8-11ec-82a8-0422ac130003")
                }
                );

            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    Id = Guid.Parse("f8f97e88-10f8-11ec-82a8-0242ac130003"),
                    Street = "290 Selwyn St",
                    City = "Christchurch",
                    Country = "New Zealand",
                    County = "Canterbury",
                    Longitude = 172.62206744255727,
                    Latitude = -43.549126911758606
                },
                new Location()
                {
                    Id = Guid.Parse("f8f9814e-10f8-11ec-82a8-0242ac130003"),
                    Street = "Riverside Market",
                    City = "Christchurch",
                    Country = "New Zealand",
                    County = "Canterbury",
                    Longitude = 172.63397647139195,
                    Latitude = -43.533927237712405
                },
                new Location()
                {
                    Id = Guid.Parse("f8f984fa-10f8-11ec-82a8-0242ac130003"),
                    Street = "409 Harewood Rd",
                    City = "Christchurch",
                    Country = "New Zealand",
                    County = "Canterbury",
                    Longitude = 172.62206744255727,
                    Latitude = -43.549126911758606
                },
                new Location()
                {
                    Id = Guid.Parse("f8f97e88-10f8-11ec-82a8-0442ac130003"),
                    Street = "247 Dairy Flat Highway",
                    City = "Auckland",
                    Country = "New Zealand",
                    County = "Auckland",
                    Longitude = 174.6936778232727,
                    Latitude = -36.72440208323365
                }
                );

           base.OnModelCreating(modelBuilder);
        }
    }
}