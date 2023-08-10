using Microsoft.EntityFrameworkCore.Migrations;

namespace MealsAPI.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Meals", new[] { "Id", "KalCount", "Name" }, new object[,]
           {
                { 1, 100, "Carrot" },
                { 2, 500, "Rice" },
                { 3, 300, "Bun" }
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
