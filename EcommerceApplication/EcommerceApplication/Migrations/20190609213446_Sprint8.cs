using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApplication.Migrations
{
    public partial class Sprint8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "CartItem",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CustomerId",
                table: "CartItem",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_AspNetUsers_CustomerId",
                table: "CartItem",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_AspNetUsers_CustomerId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CustomerId",
                table: "CartItem");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "CartItem",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
