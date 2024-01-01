using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAppEnglish.Migrations
{
    /// <inheritdoc />
    public partial class update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homework_Topic_TopicId",
                table: "Homework");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "Homework",
                newName: "topicId");

            migrationBuilder.RenameIndex(
                name: "IX_Homework_TopicId",
                table: "Homework",
                newName: "IX_Homework_topicId");

            migrationBuilder.AlterColumn<int>(
                name: "topicId",
                table: "Homework",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_Topic_topicId",
                table: "Homework",
                column: "topicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homework_Topic_topicId",
                table: "Homework");

            migrationBuilder.RenameColumn(
                name: "topicId",
                table: "Homework",
                newName: "TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Homework_topicId",
                table: "Homework",
                newName: "IX_Homework_TopicId");

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Homework",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_Topic_TopicId",
                table: "Homework",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }
    }
}
