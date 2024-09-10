using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntraVisionTest.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoCoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoLink",
                table: "Coins",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoLink",
                table: "Coins");
        }
    }
}
