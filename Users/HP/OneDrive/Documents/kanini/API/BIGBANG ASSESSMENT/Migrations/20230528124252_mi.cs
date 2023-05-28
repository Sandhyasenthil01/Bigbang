using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIGBANG_ASSESSMENT.Migrations
{
    /// <inheritdoc />
    public partial class mi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hotelid",
                table: "Staff");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hotelid",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
