﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using delivery_backend_module3.Models;

#nullable disable

namespace delivery_backend_module3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.BasketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.DishBasketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<Guid?>("BasketEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uuid");

                    b.Property<int>("DishStatus")
                        .HasColumnType("integer");

                    b.Property<Guid?>("OrderEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BasketEntityId");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("DishesInBasket");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.DishEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.RatingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("dishId")
                        .HasColumnType("uuid");

                    b.Property<int>("rating")
                        .HasColumnType("integer");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("dishId");

                    b.HasIndex("userId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.TokenEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DishEntityUserEntity", b =>
                {
                    b.Property<Guid>("DishesInBasketId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WillingUsersId")
                        .HasColumnType("uuid");

                    b.HasKey("DishesInBasketId", "WillingUsersId");

                    b.HasIndex("WillingUsersId");

                    b.ToTable("DishEntityUserEntity");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.BasketEntity", b =>
                {
                    b.HasOne("delivery_backend_module3.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.DishBasketEntity", b =>
                {
                    b.HasOne("delivery_backend_module3.Models.Entities.BasketEntity", null)
                        .WithMany("DishesInBasket")
                        .HasForeignKey("BasketEntityId");

                    b.HasOne("delivery_backend_module3.Models.Entities.DishEntity", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("delivery_backend_module3.Models.Entities.OrderEntity", null)
                        .WithMany("Dishes")
                        .HasForeignKey("OrderEntityId");

                    b.HasOne("delivery_backend_module3.Models.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("User");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.OrderEntity", b =>
                {
                    b.HasOne("delivery_backend_module3.Models.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.RatingEntity", b =>
                {
                    b.HasOne("delivery_backend_module3.Models.Entities.DishEntity", "dish")
                        .WithMany("Ratings")
                        .HasForeignKey("dishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("delivery_backend_module3.Models.Entities.UserEntity", "user")
                        .WithMany("Ratings")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dish");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DishEntityUserEntity", b =>
                {
                    b.HasOne("delivery_backend_module3.Models.Entities.DishEntity", null)
                        .WithMany()
                        .HasForeignKey("DishesInBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("delivery_backend_module3.Models.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("WillingUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.BasketEntity", b =>
                {
                    b.Navigation("DishesInBasket");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.DishEntity", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.OrderEntity", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("delivery_backend_module3.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
