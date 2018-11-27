using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ratingPKchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostRatings",
                table: "PostRatings");

            migrationBuilder.DropIndex(
                name: "IX_PostRatings_UserId",
                table: "PostRatings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostRatings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostRatings",
                table: "PostRatings",
                columns: new[] { "UserId", "PostId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostRatings",
                table: "PostRatings");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostRatings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostRatings",
                table: "PostRatings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostRatings_UserId",
                table: "PostRatings",
                column: "UserId",
                unique: true);
        }
    }
}
