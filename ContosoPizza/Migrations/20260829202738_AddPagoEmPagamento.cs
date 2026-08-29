using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class AddPagoEmPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PagoEm",
                table: "Pagamento",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagoEm",
                table: "Pagamento");
        }
    }
}
