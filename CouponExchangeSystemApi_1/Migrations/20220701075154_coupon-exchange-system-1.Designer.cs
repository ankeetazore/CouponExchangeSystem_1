﻿// <auto-generated />
using System;
using CouponExchangeSystemApi_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CouponExchangeSystemApi_1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220701075154_coupon-exchange-system-1")]
    partial class couponexchangesystem1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CouponExchangeSystemApi_1.Models.CouponCategoryDetails", b =>
                {
                    b.Property<int>("CouponCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryImagePath")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("DATE");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CouponCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("CouponCategoryDetails");
                });

            modelBuilder.Entity("CouponExchangeSystemApi_1.Models.CouponDetails", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("CouponCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("DATE");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxOff")
                        .HasColumnType("int");

                    b.Property<int?>("MinSpend")
                        .HasColumnType("int");

                    b.Property<string>("ProductList")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("DATE");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CouponId");

                    b.HasIndex("CouponCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("CouponDetails");
                });

            modelBuilder.Entity("CouponExchangeSystemApi_1.Models.UserDetails", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CouponExchangeCount")
                        .HasColumnType("int");

                    b.Property<int?>("CouponUploadCount")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<long?>("MobileNumber")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("ProfilePath")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("UserId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("CouponExchangeSystemApi_1.Models.UserLoginDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLoginDetails");
                });

            modelBuilder.Entity("CouponExchangeSystemApi_1.Models.CouponCategoryDetails", b =>
                {
                    b.HasOne("CouponExchangeSystemApi_1.Models.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("CouponExchangeSystemApi_1.Models.CouponDetails", b =>
                {
                    b.HasOne("CouponExchangeSystemApi_1.Models.CouponCategoryDetails", "CouponCategoryDetails")
                        .WithMany()
                        .HasForeignKey("CouponCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CouponExchangeSystemApi_1.Models.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CouponCategoryDetails");

                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("CouponExchangeSystemApi_1.Models.UserLoginDetails", b =>
                {
                    b.HasOne("CouponExchangeSystemApi_1.Models.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetails");
                });
#pragma warning restore 612, 618
        }
    }
}