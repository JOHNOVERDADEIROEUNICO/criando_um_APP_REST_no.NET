using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyPromocaoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPromocao",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromocaoId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PromocaoId",
                table: "Pedido",
                column: "PromocaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Promocao_PromocaoId",
                table: "Pedido",
                column: "PromocaoId",
                principalTable: "Promocao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Promocao_PromocaoId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_PromocaoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdPromocao",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "PromocaoId",
                table: "Pedido");
        }
    }
}
