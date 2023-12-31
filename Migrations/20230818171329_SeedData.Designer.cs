﻿// <auto-generated />
using AnimalShelterApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalShelterApi.Migrations
{
    [DbContext(typeof(AnimalShelterApiContext))]
    [Migration("20230818171329_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AnimalShelterApi.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("CatId");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            Age = 7,
                            Breed = "Mutt",
                            Name = "Reina"
                        },
                        new
                        {
                            CatId = 2,
                            Age = 10,
                            Breed = "LongHairSomething",
                            Name = "TBone"
                        },
                        new
                        {
                            CatId = 3,
                            Age = 2,
                            Breed = "Bitter",
                            Name = "King"
                        },
                        new
                        {
                            CatId = 4,
                            Age = 4,
                            Breed = "Tabby",
                            Name = "Macaroni"
                        },
                        new
                        {
                            CatId = 5,
                            Age = 22,
                            Breed = "Hairless",
                            Name = "BongWater"
                        });
                });

            modelBuilder.Entity("AnimalShelterApi.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("DogId");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            DogId = 1,
                            Age = 7,
                            Breed = "Golden Retriever",
                            Name = "Matilda"
                        },
                        new
                        {
                            DogId = 2,
                            Age = 10,
                            Breed = "Germain Sheppard",
                            Name = "Rexie"
                        },
                        new
                        {
                            DogId = 3,
                            Age = 2,
                            Breed = "Boxer",
                            Name = "Matilda"
                        },
                        new
                        {
                            DogId = 4,
                            Age = 4,
                            Breed = "Pitt Bull",
                            Name = "Pip"
                        },
                        new
                        {
                            DogId = 5,
                            Age = 22,
                            Breed = "Frenchie",
                            Name = "Bartholomew"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
