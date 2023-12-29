using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAppEnglish.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListWord_users_UserId",
                table: "ListWord");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ListWord",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "definition",
                table: "ListWord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ListWord_users_UserId",
                table: "ListWord",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListWord_users_UserId",
                table: "ListWord");

            migrationBuilder.DropColumn(
                name: "definition",
                table: "ListWord");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ListWord",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ListWord_users_UserId",
                table: "ListWord",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
