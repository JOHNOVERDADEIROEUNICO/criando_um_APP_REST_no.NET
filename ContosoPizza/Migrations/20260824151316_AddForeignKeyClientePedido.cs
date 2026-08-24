using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyClientePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Clientes_ClienteId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Clientes_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Clientes_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Clientes_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
