using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyPizzaIdPromocao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Promocao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Promocao_PizzaId",
                table: "Promocao",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promocao_Pizza_PizzaId",
                table: "Promocao",
                column: "PizzaId",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promocao_Pizza_PizzaId",
                table: "Promocao");

            migrationBuilder.DropIndex(
                name: "IX_Promocao_PizzaId",
                table: "Promocao");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Promocao");
        }
    }
}
