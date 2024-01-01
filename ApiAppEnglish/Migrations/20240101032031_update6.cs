using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAppEnglish.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Homework",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homework_TopicId",
                table: "Homework",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homework_Topic_TopicId",
                table: "Homework",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homework_Topic_TopicId",
                table: "Homework");

            migrationBuilder.DropIndex(
                name: "IX_Homework_TopicId",
                table: "Homework");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Homework");
        }
    }
}
