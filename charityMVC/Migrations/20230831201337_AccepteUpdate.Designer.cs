﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using charityMVC;

#nullable disable

namespace charityMVC.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230831201337_AccepteUpdate")]
    partial class AccepteUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("charityMVC.Models.Accepted", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("fullAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("points")
                        .HasColumnType("integer");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Accepteds");
                });

            modelBuilder.Entity("charityMVC.Models.Admin", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("isSuperAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("charityMVC.Models.Clerk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("clerk");
                });

            modelBuilder.Entity("charityMVC.Models.Roles", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("charityMVC.Models.Support", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fullAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("points")
                        .HasColumnType("integer");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("support");
                });

            modelBuilder.Entity("charityMVC.Models.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("_proxy_account_number")
                        .HasColumnType("text");

                    b.Property<string>("_proxy_name")
                        .HasColumnType("text");

                    b.Property<string>("bank_account_number")
                        .HasColumnType("text");

                    b.Property<string>("birthDate")
                        .HasColumnType("text");

                    b.Property<int?>("children_count")
                        .HasColumnType("integer");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<bool>("debt")
                        .HasColumnType("boolean");

                    b.Property<string>("debt_proof")
                        .HasColumnType("text");

                    b.Property<bool>("disability")
                        .HasColumnType("boolean");

                    b.Property<string>("disability_proof")
                        .HasColumnType("text");

                    b.Property<bool>("elderly")
                        .HasColumnType("boolean");

                    b.Property<string>("family_card_image")
                        .HasColumnType("text");

                    b.Property<string>("fullAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("house_rent")
                        .HasColumnType("boolean");

                    b.Property<string>("id_image")
                        .HasColumnType("text");

                    b.Property<bool>("income_support")
                        .HasColumnType("boolean");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<int?>("points")
                        .HasColumnType("integer");

                    b.Property<bool>("proxy")
                        .HasColumnType("boolean");

                    b.Property<string>("rent_proof")
                        .HasColumnType("text");

                    b.Property<bool>("widow")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("charityMVC.Models.points", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("children_count_1")
                        .HasColumnType("integer");

                    b.Property<int>("children_count_2")
                        .HasColumnType("integer");

                    b.Property<int>("children_count_3")
                        .HasColumnType("integer");

                    b.Property<int>("children_count_4")
                        .HasColumnType("integer");

                    b.Property<int>("children_count_4p")
                        .HasColumnType("integer");

                    b.Property<int>("elderly")
                        .HasColumnType("integer");

                    b.Property<int>("hasNo_income_support")
                        .HasColumnType("integer");

                    b.Property<int>("has_debt")
                        .HasColumnType("integer");

                    b.Property<int>("has_disability")
                        .HasColumnType("integer");

                    b.Property<int>("house_is_rent")
                        .HasColumnType("integer");

                    b.Property<int>("pointValue")
                        .HasColumnType("integer");

                    b.Property<int>("widow")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("points");
                });
#pragma warning restore 612, 618
        }
    }
}
