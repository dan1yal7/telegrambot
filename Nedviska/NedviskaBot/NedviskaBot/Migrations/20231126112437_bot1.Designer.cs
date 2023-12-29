﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NedviskaBot.Database;

#nullable disable

namespace NedviskaBot.Migrations
{
    [DbContext(typeof(BotDbContext))]
    [Migration("20231126112437_bot1")]
    partial class bot1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("NedviskaBot.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequestsPerDay")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Subscription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("TelegramUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}