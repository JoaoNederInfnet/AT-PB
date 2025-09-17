using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCompras.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCartaoEnderecoEProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteCep",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteCreditCardCvv",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteCreditCardExpireDate",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteCreditCardFlag",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteCreditCardNumber",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteCreditCardOwnerName",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteImovelNumber",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ClientePassword",
                table: "Clientes",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "ClienteEmail",
                table: "Clientes",
                newName: "Email");

            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDoTitular = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Cvv = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDeValidade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Bandeira = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<long>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cep = table.Column<int>(type: "INTEGER", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<long>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<string>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ClienteId",
                table: "Cartoes",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Clientes",
                newName: "ClientePassword");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clientes",
                newName: "ClienteEmail");

            migrationBuilder.AddColumn<int>(
                name: "ClienteCep",
                table: "Clientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteCreditCardCvv",
                table: "Clientes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClienteCreditCardExpireDate",
                table: "Clientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClienteCreditCardFlag",
                table: "Clientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClienteCreditCardNumber",
                table: "Clientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClienteCreditCardOwnerName",
                table: "Clientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteImovelNumber",
                table: "Clientes",
                type: "INTEGER",
                nullable: true);
        }
    }
}
