using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TrainReservationApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrenAdi = table.Column<string>(type: "text", nullable: false),
                    VagonAdi = table.Column<string>(type: "text", nullable: false),
                    KisiSayisi = table.Column<int>(type: "integer", nullable: false),
                    Tarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vagonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Kapasite = table.Column<int>(type: "integer", nullable: false),
                    DoluKoltukAdet = table.Column<int>(type: "integer", nullable: false),
                    TrenId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagonlar_Trenler_TrenId",
                        column: x => x.TrenId,
                        principalTable: "Trenler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vagonlar_TrenId",
                table: "Vagonlar",
                column: "TrenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Vagonlar");

            migrationBuilder.DropTable(
                name: "Trenler");
        }
    }
}
