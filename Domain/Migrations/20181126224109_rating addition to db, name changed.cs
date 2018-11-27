using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ratingadditiontodbnamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUp",
                table: "PostRatings",
                newName: "IsRated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRated",
                table: "PostRatings",
                newName: "IsUp");
        }
    }
}
