using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutsAPI.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Workouts", new[] { "Id", "KalCount", "Name" }, new object[,]
         {
                { 1, 100, "Pushup" },
                { 2, 500, "Situp" },
                { 3, 300, "Pullup" }
         });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
