using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAutorization.Migrations
{
    /// <inheritdoc />
    public partial class mfinal5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "FIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FIO",
                table: "Students",
                newName: "Name");
        }
    }
}
