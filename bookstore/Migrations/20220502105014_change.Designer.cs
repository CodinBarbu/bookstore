﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookstore.Data;

namespace bookstore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220502105014_change")]
    partial class change
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bookstore.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autori");
                });

            modelBuilder.Entity("bookstore.Models.Autor_Carte", b =>
                {
                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("CarteId")
                        .HasColumnType("int");

                    b.HasKey("AutorId", "CarteId");

                    b.HasIndex("CarteId");

                    b.ToTable("Autori_Carti");
                });

            modelBuilder.Entity("bookstore.Models.Carte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookCategory")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EdituraId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StartDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EdituraId");

                    b.ToTable("Carti");
                });

            modelBuilder.Entity("bookstore.Models.Editura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Edituri");
                });

            modelBuilder.Entity("bookstore.Models.Autor_Carte", b =>
                {
                    b.HasOne("bookstore.Models.Autor", "Autor")
                        .WithMany("Autori_Carti")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bookstore.Models.Carte", "Carte")
                        .WithMany("Autori_Carti")
                        .HasForeignKey("CarteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Carte");
                });

            modelBuilder.Entity("bookstore.Models.Carte", b =>
                {
                    b.HasOne("bookstore.Models.Editura", "Editura")
                        .WithMany("Carti")
                        .HasForeignKey("EdituraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editura");
                });

            modelBuilder.Entity("bookstore.Models.Autor", b =>
                {
                    b.Navigation("Autori_Carti");
                });

            modelBuilder.Entity("bookstore.Models.Carte", b =>
                {
                    b.Navigation("Autori_Carti");
                });

            modelBuilder.Entity("bookstore.Models.Editura", b =>
                {
                    b.Navigation("Carti");
                });
#pragma warning restore 612, 618
        }
    }
}
