﻿// <auto-generated />
using System;
using AluraChallenge.Adopet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AluraChallenge.Adopet.Data.Migrations
{
    [DbContext(typeof(AdopetDbContext))]
    partial class AdopetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Adopet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.HasIndex("TutorId")
                        .IsUnique();

                    b.ToTable("Adopets", (string)null);
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Adopeted")
                        .HasColumnType("bit");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Behavior")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("ShelterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specimen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShelterId");

                    b.ToTable("Pets", (string)null);
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Shelter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique()
                        .HasFilter("[CityId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Shelters", (string)null);
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Tutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("AddressDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique()
                        .HasFilter("[CityId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Tutors", (string)null);
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Adopet", b =>
                {
                    b.HasOne("AluraChallenge.Adopet.Domain.Pet", "Pet")
                        .WithOne()
                        .HasForeignKey("AluraChallenge.Adopet.Domain.Adopet", "PetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AluraChallenge.Adopet.Domain.Tutor", "Tutor")
                        .WithOne()
                        .HasForeignKey("AluraChallenge.Adopet.Domain.Adopet", "TutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Pet", b =>
                {
                    b.HasOne("AluraChallenge.Adopet.Domain.Shelter", "Shelter")
                        .WithMany("Pets")
                        .HasForeignKey("ShelterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shelter");
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Shelter", b =>
                {
                    b.HasOne("AluraChallenge.Adopet.Domain.City", "City")
                        .WithOne()
                        .HasForeignKey("AluraChallenge.Adopet.Domain.Shelter", "CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AluraChallenge.Adopet.Domain.User", "User")
                        .WithOne()
                        .HasForeignKey("AluraChallenge.Adopet.Domain.Shelter", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AluraChallenge.Adopet.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ShelterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(250)")
                                .HasColumnName("Email");

                            b1.HasKey("ShelterId");

                            b1.ToTable("Shelters");

                            b1.WithOwner()
                                .HasForeignKey("ShelterId");
                        });

                    b.Navigation("City");

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Tutor", b =>
                {
                    b.HasOne("AluraChallenge.Adopet.Domain.City", "City")
                        .WithOne()
                        .HasForeignKey("AluraChallenge.Adopet.Domain.Tutor", "CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AluraChallenge.Adopet.Domain.User", "User")
                        .WithOne()
                        .HasForeignKey("AluraChallenge.Adopet.Domain.Tutor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AluraChallenge.Adopet.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("TutorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(250)")
                                .HasColumnName("Email");

                            b1.HasKey("TutorId");

                            b1.ToTable("Tutors");

                            b1.WithOwner()
                                .HasForeignKey("TutorId");
                        });

                    b.Navigation("City");

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AluraChallenge.Adopet.Domain.Shelter", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
