﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReducibleNodeDemo;

namespace ReducibleNodeDemo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181019114110_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReducibleNodeDemo.Bar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Bars");

                    b.HasData(
                        new { Id = 3, Value = "Bar3" },
                        new { Id = 4, Value = "Bar4" }
                    );
                });

            modelBuilder.Entity("ReducibleNodeDemo.Foo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Foos");

                    b.HasData(
                        new { Id = 1 },
                        new { Id = 2 }
                    );
                });

            modelBuilder.Entity("ReducibleNodeDemo.FooBar", b =>
                {
                    b.Property<int>("FooId");

                    b.Property<int>("BarId");

                    b.HasKey("FooId", "BarId");

                    b.HasIndex("BarId");

                    b.ToTable("FooBars");

                    b.HasData(
                        new { FooId = 1, BarId = 3 },
                        new { FooId = 1, BarId = 4 },
                        new { FooId = 2, BarId = 3 },
                        new { FooId = 2, BarId = 4 }
                    );
                });

            modelBuilder.Entity("ReducibleNodeDemo.FooBar", b =>
                {
                    b.HasOne("ReducibleNodeDemo.Bar", "Bar")
                        .WithMany("FooBars")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReducibleNodeDemo.Foo", "Foo")
                        .WithMany("FooBars")
                        .HasForeignKey("FooId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
