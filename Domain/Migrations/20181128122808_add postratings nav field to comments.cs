using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class addpostratingsnavfieldtocomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostRatings_PostId",
                table: "PostRatings",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRatings_Comments_PostId",
                table: "PostRatings",
                column: "PostId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostRatings_Comments_PostId",
                table: "PostRatings");

            migrationBuilder.DropIndex(
                name: "IX_PostRatings_PostId",
                table: "PostRatings");
        }
    }
}
