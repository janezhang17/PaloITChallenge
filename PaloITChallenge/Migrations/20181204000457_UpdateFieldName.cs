using Microsoft.EntityFrameworkCore.Migrations;

namespace PaloITChallenge.Migrations
{
    public partial class UpdateFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SumOfAsciiValueInBinary",
                table: "FullNames",
                newName: "SumOfAsciiValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SumOfAsciiValue",
                table: "FullNames",
                newName: "SumOfAsciiValueInBinary");
        }
    }
}
