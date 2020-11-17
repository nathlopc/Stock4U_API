﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S4U.Persistance.Contexts;

namespace S4U.Persistance.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20201116213026_Notes")]
    partial class Notes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("S4U.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Compliment")
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Neighborhood")
                        .HasMaxLength(100);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("Id", "ZipCode")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("S4U.Domain.Entities.Equity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("Id", "Ticker");

                    b.ToTable("Equities");
                });

            modelBuilder.Entity("S4U.Domain.Entities.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Alert");

                    b.Property<string>("Attach")
                        .HasMaxLength(256);

                    b.Property<string>("Comments")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<Guid>("EquityID");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID", "EquityID");

                    b.HasIndex("Id", "UserID", "EquityID", "Alert");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("S4U.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("PaymentType");

                    b.Property<Guid?>("PlanId");

                    b.Property<Guid?>("SignatureId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("SignatureId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("S4U.Domain.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descyption")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("Id", "Name");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("S4U.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id", "Name");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = new Guid("a8fe4874-562f-4f4a-9f83-6b47fce6792d"), Name = "Administrator" },
                        new { Id = new Guid("d06ada51-cfd0-463b-a855-ce7c9dbe8d63"), Name = "Client" }
                    );
                });

            modelBuilder.Entity("S4U.Domain.Entities.Signature", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("ExpiredDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<Guid>("PlanID");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("PlanID");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("S4U.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressID");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Gender")
                        .HasMaxLength(11);

                    b.Property<string>("Image")
                        .HasMaxLength(256);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PushToken");

                    b.Property<Guid>("RoleID");

                    b.Property<Guid?>("SignatureID");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.HasIndex("RoleID");

                    b.HasIndex("Id", "Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("S4U.Domain.Entities.UserEquity", b =>
                {
                    b.Property<Guid>("UserID");

                    b.Property<Guid>("EquityID");

                    b.HasKey("UserID", "EquityID");

                    b.HasAlternateKey("EquityID", "UserID");

                    b.HasIndex("UserID", "EquityID");

                    b.ToTable("UserEquities");
                });

            modelBuilder.Entity("S4U.Domain.Entities.Note", b =>
                {
                    b.HasOne("S4U.Domain.Entities.UserEquity", "UserEquity")
                        .WithMany("Notes")
                        .HasForeignKey("UserID", "EquityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S4U.Domain.Entities.Payment", b =>
                {
                    b.HasOne("S4U.Domain.Entities.Plan")
                        .WithMany("Payments")
                        .HasForeignKey("PlanId");

                    b.HasOne("S4U.Domain.Entities.Signature")
                        .WithMany("Payments")
                        .HasForeignKey("SignatureId");
                });

            modelBuilder.Entity("S4U.Domain.Entities.Signature", b =>
                {
                    b.HasOne("S4U.Domain.Entities.User", "User")
                        .WithOne("Signature")
                        .HasForeignKey("S4U.Domain.Entities.Signature", "Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S4U.Domain.Entities.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S4U.Domain.Entities.User", b =>
                {
                    b.HasOne("S4U.Domain.Entities.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressID");

                    b.HasOne("S4U.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("S4U.Domain.Entities.UserEquity", b =>
                {
                    b.HasOne("S4U.Domain.Entities.Equity", "Equity")
                        .WithMany("UsersEquities")
                        .HasForeignKey("EquityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("S4U.Domain.Entities.User", "User")
                        .WithMany("UsersEquities")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
