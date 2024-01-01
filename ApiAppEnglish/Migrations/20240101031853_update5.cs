using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAppEnglish.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListWord_users_UserId",
                table: "ListWord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "answers",
                table: "Homework");

            migrationBuilder.DropColumn(
                name: "questions",
                table: "Homework");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "Homework",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "Homework",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DetailHomeWork",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    homeworkId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailHomeWork", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetailHomeWork_Homework_homeworkId",
                        column: x => x.homeworkId,
                        principalTable: "Homework",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailHomeWork_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailHomeWork_homeworkId",
                table: "DetailHomeWork",
                column: "homeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailHomeWork_userId",
                table: "DetailHomeWork",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListWord_User_UserId",
                table: "ListWord",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListWord_User_UserId",
                table: "ListWord");

            migrationBuilder.DropTable(
                name: "DetailHomeWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isDone",
                table: "Homework");

            migrationBuilder.DropColumn(
                name: "score",
                table: "Homework");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.AddColumn<string>(
                name: "answers",
                table: "Homework",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "questions",
                table: "Homework",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListWord_users_UserId",
                table: "ListWord",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
