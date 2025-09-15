using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCompras.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ClientePassword = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteCep = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteImovelNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteCreditCardOwnerName = table.Column<string>(type: "TEXT", nullable: true),
                    ClienteCreditCardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ClienteCreditCardCvv = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteCreditCardExpireDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ClienteCreditCardFlag = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
