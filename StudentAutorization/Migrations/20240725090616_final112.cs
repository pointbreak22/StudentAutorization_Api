using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAutorization.Migrations
{
    /// <inheritdoc />
    public partial class final112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teachers",
                newName: "FIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FIO",
                table: "Teachers",
                newName: "Name");
        }
    }
}
