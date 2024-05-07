﻿// <auto-generated />
using System;
using Everflow.EventPlanner.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Everflow.EventPlanner.Persistence.Migrations
{
    [DbContext(typeof(EverflowContext))]
    [Migration("20240507222019_BaseInit")]
    partial class BaseInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Everflow.EventPlanner.Domain.Features.Events.EventDetail", b =>
                {
                    b.Property<int>("EventDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventDetailId"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("EventDetailDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDetailDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<TimeSpan?>("EventDetailEndTime")
                        .IsRequired()
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("EventDetailStartTime")
                        .IsRequired()
                        .HasColumnType("time");

                    b.HasKey("EventDetailId");

                    b.ToTable("EventDetail", (string)null);
                });

            modelBuilder.Entity("Everflow.EventPlanner.Domain.Features.Events.EventPerson", b =>
                {
                    b.Property<int>("EventPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventPersonId"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("EventDetailId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("EventPersonId");

                    b.HasIndex("EventDetailId");

                    b.HasIndex("PersonId", "EventDetailId")
                        .IsUnique();

                    b.ToTable("EventPerson", (string)null);
                });

            modelBuilder.Entity("Everflow.EventPlanner.Domain.Features.People.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<DateTime>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PersonId");

                    b.ToTable("Person", (string)null);

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CreatedDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "john_doe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "johnDoe1"
                        });
                });

            modelBuilder.Entity("Everflow.EventPlanner.Domain.Features.Events.EventPerson", b =>
                {
                    b.HasOne("Everflow.EventPlanner.Domain.Features.Events.EventDetail", "EventDetail")
                        .WithMany("EventPersons")
                        .HasForeignKey("EventDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Everflow.EventPlanner.Domain.Features.People.Person", "Person")
                        .WithMany("EventPersons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventDetail");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Everflow.EventPlanner.Domain.Features.Events.EventDetail", b =>
                {
                    b.Navigation("EventPersons");
                });

            modelBuilder.Entity("Everflow.EventPlanner.Domain.Features.People.Person", b =>
                {
                    b.Navigation("EventPersons");
                });
#pragma warning restore 612, 618
        }
    }
}