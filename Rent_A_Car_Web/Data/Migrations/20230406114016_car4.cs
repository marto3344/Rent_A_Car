using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Car_Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class car4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_RentedByUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RentedByUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RendedByUserId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "RentedByUserId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_UserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "RentedByUserId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RendedByUserId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentedByUserId",
                table: "Cars",
                column: "RentedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_RentedByUserId",
                table: "Cars",
                column: "RentedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
