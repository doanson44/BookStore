using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreData.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionForBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Book");
        }
    }
}
