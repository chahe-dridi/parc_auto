﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parc_auto_v1.Models;

#nullable disable

namespace parc_auto_v1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240715090118_t")]
    partial class t
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("parc_auto_v1.Models.Assurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alert")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateEchance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateValide")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoitureId");

                    b.ToTable("Assurances");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Demandes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AffectationDepartement")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateArrivee")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDepart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Etat")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdEmploye")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mission")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NiveauPriorite")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TypeVoiture")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoitureId");

                    b.ToTable("Demandes");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Sinistre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AcceptationPourFixe")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateDommage")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtatDeVoiture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PrixFixe")
                        .HasColumnType("bigint");

                    b.Property<int>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoitureId");

                    b.ToTable("Sinistres");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Vidange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateIntervention")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kilometrage")
                        .HasColumnType("int");

                    b.Property<decimal>("MontantHt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NFacture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperationDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeIntervention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoitureId");

                    b.ToTable("Vidanges");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Vignette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alert")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("DateEchance")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateValide")
                        .HasColumnType("date");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoitureId");

                    b.ToTable("Vignettes");
                });

            modelBuilder.Entity("parc_auto_v1.Models.VisiteTechnique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alert")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateEchance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateValide")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VoitureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoitureId");

                    b.ToTable("VisiteTechniques");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Voiture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Carburant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Disponibilite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Etat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Km")
                        .HasColumnType("int");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeVoiture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Assurance", b =>
                {
                    b.HasOne("parc_auto_v1.Models.Voiture", "Voiture")
                        .WithMany("Assurances")
                        .HasForeignKey("VoitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Demandes", b =>
                {
                    b.HasOne("parc_auto_v1.Models.Voiture", "Voiture")
                        .WithMany()
                        .HasForeignKey("VoitureId");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Sinistre", b =>
                {
                    b.HasOne("parc_auto_v1.Models.Voiture", "Voiture")
                        .WithMany("Sinistres")
                        .HasForeignKey("VoitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Vidange", b =>
                {
                    b.HasOne("parc_auto_v1.Models.Voiture", "Voiture")
                        .WithMany("Vidanges")
                        .HasForeignKey("VoitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Vignette", b =>
                {
                    b.HasOne("parc_auto_v1.Models.Voiture", "Voiture")
                        .WithMany("Vignettes")
                        .HasForeignKey("VoitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("parc_auto_v1.Models.VisiteTechnique", b =>
                {
                    b.HasOne("parc_auto_v1.Models.Voiture", "Voiture")
                        .WithMany("VisiteTechniques")
                        .HasForeignKey("VoitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("parc_auto_v1.Models.Voiture", b =>
                {
                    b.Navigation("Assurances");

                    b.Navigation("Sinistres");

                    b.Navigation("Vidanges");

                    b.Navigation("Vignettes");

                    b.Navigation("VisiteTechniques");
                });
#pragma warning restore 612, 618
        }
    }
}
