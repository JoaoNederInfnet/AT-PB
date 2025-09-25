using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCompras.Migrations
{
    /// <inheritdoc />
    public partial class Pedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AdmProdutosId",
                table: "Produtos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PedidoId",
                table: "Produtos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<long>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_AdmProdutosId",
                table: "Produtos",
                column: "AdmProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_AdmsProdutos_AdmProdutosId",
                table: "Produtos",
                column: "AdmProdutosId",
                principalTable: "AdmsProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_AdmsProdutos_AdmProdutosId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_AdmProdutosId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "AdmProdutosId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Produtos");
        }
    }
}
