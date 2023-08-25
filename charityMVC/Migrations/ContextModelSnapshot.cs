﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using charityMVC;

#nullable disable

namespace charityMVC.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                    b.Property<string>("id")
                        .HasColumnType("text");

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

                    b.HasKey("id");

                    b.ToTable("clerk");
                });

            modelBuilder.Entity("charityMVC.Models.Support", b =>
                {
                    b.Property<string>("SupportId")
                        .HasColumnType("text");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DocumentUrl")
                        .HasColumnType("text");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("SupportId");

                    b.ToTable("support");
                });

            modelBuilder.Entity("charityMVC.Models.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("bank_account_number")
                        .HasColumnType("text");

                    b.Property<string>("birthDate")
                        .HasColumnType("text");

                    b.Property<int?>("children_count")
                        .HasColumnType("integer");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<bool?>("debt")
                        .HasColumnType("boolean");

                    b.Property<string>("debt_proof")
                        .HasColumnType("text");

                    b.Property<bool?>("disability")
                        .HasColumnType("boolean");

                    b.Property<string>("disability_proof")
                        .HasColumnType("text");

                    b.Property<bool?>("elderly")
                        .HasColumnType("boolean");

                    b.Property<string>("family_card_image")
                        .HasColumnType("text");

                    b.Property<string>("fullAddress")
                        .HasColumnType("text");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("house_rent")
                        .HasColumnType("boolean");

                    b.Property<string>("id_image")
                        .HasColumnType("text");

                    b.Property<bool?>("income_support")
                        .HasColumnType("boolean");

                    b.Property<string>("income_supportImg")
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<int?>("points")
                        .HasColumnType("integer");

                    b.Property<bool?>("proxy")
                        .HasColumnType("boolean");

                    b.Property<string>("proxy_account_number")
                        .HasColumnType("text");

                    b.Property<string>("proxy_name")
                        .HasColumnType("text");

                    b.Property<string>("rent_proof")
                        .HasColumnType("text");

                    b.Property<bool?>("widow")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}
