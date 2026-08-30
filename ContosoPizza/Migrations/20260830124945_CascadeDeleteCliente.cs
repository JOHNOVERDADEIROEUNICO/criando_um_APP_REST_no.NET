using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Pizza_PizzaId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Clientes_UsuarioId",
                table: "Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Pizza_PizzaId",
                table: "ItemPedido",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Clientes_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Pizza_PizzaId",
                table: "ItemPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Clientes_UsuarioId",
                table: "Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Pizza_PizzaId",
                table: "ItemPedido",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Clientes_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
