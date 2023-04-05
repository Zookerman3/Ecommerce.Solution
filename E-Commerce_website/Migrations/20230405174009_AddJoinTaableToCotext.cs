using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceSite.Migrations
{
    public partial class AddJoinTaableToCotext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppuserProduct_AspNetUsers_UserID",
                table: "AppuserProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppuserProduct",
                table: "AppuserProduct");

            migrationBuilder.RenameTable(
                name: "AppuserProduct",
                newName: "AppuserProducts");

            migrationBuilder.RenameIndex(
                name: "IX_AppuserProduct_UserID",
                table: "AppuserProducts",
                newName: "IX_AppuserProducts_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppuserProducts",
                table: "AppuserProducts",
                column: "AppuserProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppuserProducts_AspNetUsers_UserID",
                table: "AppuserProducts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppuserProducts_AspNetUsers_UserID",
                table: "AppuserProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppuserProducts",
                table: "AppuserProducts");

            migrationBuilder.RenameTable(
                name: "AppuserProducts",
                newName: "AppuserProduct");

            migrationBuilder.RenameIndex(
                name: "IX_AppuserProducts_UserID",
                table: "AppuserProduct",
                newName: "IX_AppuserProduct_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppuserProduct",
                table: "AppuserProduct",
                column: "AppuserProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppuserProduct_AspNetUsers_UserID",
                table: "AppuserProduct",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
