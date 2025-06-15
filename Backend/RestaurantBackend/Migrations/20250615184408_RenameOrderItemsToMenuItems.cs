using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBackend.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrderItemsToMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderItems");
        }
    }
}
