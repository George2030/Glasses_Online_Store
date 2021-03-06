﻿// <auto-generated />
using Glasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Glasses.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20181214125115_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Glasses.Models.Brand", b =>
                {
                    b.Property<int>("Brand_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Glassbrand");

                    b.HasKey("Brand_ID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Glasses.Models.Glass", b =>
                {
                    b.Property<int>("Glass_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Brand_ID");

                    b.Property<string>("GName");

                    b.Property<decimal>("Price");

                    b.HasKey("Glass_ID");

                    b.HasIndex("Brand_ID");

                    b.ToTable("Glasses");
                });

            modelBuilder.Entity("Glasses.Models.Glass", b =>
                {
                    b.HasOne("Glasses.Models.Brand", "Brand")
                        .WithMany("Glasses")
                        .HasForeignKey("Brand_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
