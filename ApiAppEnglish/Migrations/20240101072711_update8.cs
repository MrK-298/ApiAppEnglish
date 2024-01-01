using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAppEnglish.Migrations
{
    /// <inheritdoc />
    public partial class update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDone",
                table: "Homework");

            migrationBuilder.DropColumn(
                name: "score",
                table: "Homework");

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "DetailHomeWork",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "DetailHomeWork",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDone",
                table: "DetailHomeWork");

            migrationBuilder.DropColumn(
                name: "score",
                table: "DetailHomeWork");

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
        }
    }
}
