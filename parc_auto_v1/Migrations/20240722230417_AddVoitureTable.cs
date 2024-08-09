using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parc_auto_v1.Migrations
{
    /// <inheritdoc />
    public partial class AddVoitureTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modeles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modeles_Marques_MarqueId",
                        column: x => x.MarqueId,
                        principalTable: "Marques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeVoiture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarqueId = table.Column<int>(type: "int", nullable: false),
                    ModeleId = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    Carburant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibilite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voitures_Marques_MarqueId",
                        column: x => x.MarqueId,
                        principalTable: "Marques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voitures_Modeles_ModeleId",
                        column: x => x.ModeleId,
                        principalTable: "Modeles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEchance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateValide = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alert = table.Column<bool>(type: "bit", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assurances_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdEmploye = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AffectationDepartement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeVoiture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateDepart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateArrivee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Mission = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: true),
                    Etat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demandes_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinistres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDommage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptationPourFixe = table.Column<bool>(type: "bit", nullable: false),
                    EtatDeVoiture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixFixe = table.Column<long>(type: "bigint", nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinistres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinistres_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vidanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIntervention = table.Column<DateOnly>(type: "date", nullable: false),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NFacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometrage = table.Column<int>(type: "int", nullable: false),
                    OperationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vidanges_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vignettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEchance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateValide = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alert = table.Column<bool>(type: "bit", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vignettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vignettes_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisiteTechniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEchance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateValide = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alert = table.Column<bool>(type: "bit", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VoitureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisiteTechniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisiteTechniques_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assurances_VoitureId",
                table: "Assurances",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_VoitureId",
                table: "Demandes",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Modeles_MarqueId",
                table: "Modeles",
                column: "MarqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinistres_VoitureId",
                table: "Sinistres",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Vidanges_VoitureId",
                table: "Vidanges",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Vignettes_VoitureId",
                table: "Vignettes",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_VisiteTechniques_VoitureId",
                table: "VisiteTechniques",
                column: "VoitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_MarqueId",
                table: "Voitures",
                column: "MarqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_ModeleId",
                table: "Voitures",
                column: "ModeleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assurances");

            migrationBuilder.DropTable(
                name: "Demandes");

            migrationBuilder.DropTable(
                name: "Sinistres");

            migrationBuilder.DropTable(
                name: "Vidanges");

            migrationBuilder.DropTable(
                name: "Vignettes");

            migrationBuilder.DropTable(
                name: "VisiteTechniques");

            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DropTable(
                name: "Modeles");

            migrationBuilder.DropTable(
                name: "Marques");
        }
    }
}
