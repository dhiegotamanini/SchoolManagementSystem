using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
            name: "Teacher",
            newName: "Teachers"
        );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
           name: "Teachers",
           newName: "Teacher"
       );
        }
    }
}
