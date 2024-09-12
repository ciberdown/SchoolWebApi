using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schools_Name",
                table: "Schools");
        }
    }
}
