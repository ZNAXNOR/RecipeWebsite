using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class RecipeIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientQuantity",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IngredientUnitOfMeasurement",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "IngredientName",
                table: "Posts",
                newName: "Ingredient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingredient",
                table: "Posts",
                newName: "IngredientName");

            migrationBuilder.AddColumn<decimal>(
                name: "IngredientQuantity",
                table: "Posts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IngredientUnitOfMeasurement",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
