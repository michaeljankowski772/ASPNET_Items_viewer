﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnet_project.Data;

#nullable disable

namespace aspnet_project.Migrations
{
    [DbContext(typeof(ItemContext))]
    [Migration("20241213223206_Initial migration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("aspnet_project.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Armor")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhysicalReductionPercent")
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Armor = 12,
                            ImageURL = "https://static.wikia.nocookie.net/tibia/images/d/d0/Golden_Armor.gif/revision/latest?cb=20050613134413&path-prefix=en&format=original",
                            Name = "Golden Armor",
                            PhysicalReductionPercent = 0,
                            SlotId = 0
                        });
                });

            modelBuilder.Entity("aspnet_project.Models.ItemSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemSets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Golden set"
                        });
                });

            modelBuilder.Entity("aspnet_project.Models.ItemSetItems", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ItemSetId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "ItemSetId");

                    b.HasIndex("ItemSetId");

                    b.ToTable("ItemSetItems");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            ItemSetId = 1
                        });
                });

            modelBuilder.Entity("aspnet_project.Models.ItemSetItems", b =>
                {
                    b.HasOne("aspnet_project.Models.Item", "Item")
                        .WithMany("ItemSetItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aspnet_project.Models.ItemSet", "ItemSet")
                        .WithMany("ItemSetItems")
                        .HasForeignKey("ItemSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ItemSet");
                });

            modelBuilder.Entity("aspnet_project.Models.Item", b =>
                {
                    b.Navigation("ItemSetItems");
                });

            modelBuilder.Entity("aspnet_project.Models.ItemSet", b =>
                {
                    b.Navigation("ItemSetItems");
                });
#pragma warning restore 612, 618
        }
    }
}
