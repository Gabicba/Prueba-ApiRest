using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEncode2.Migrations
{
    /// <inheritdoc />
    public partial class AgregarValidacionesCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Categorias");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Categorias",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Categorias");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
