using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Car_Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class cars3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RendedByUserId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RendedByUserId",
                table: "Cars");
        }
    }
}
