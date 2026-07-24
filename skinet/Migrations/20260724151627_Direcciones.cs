using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skinet.Migrations
{
    /// <inheritdoc />
    public partial class Direcciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "AspNetUsers",
                newName: "nombre");

            migrationBuilder.AddColumn<int>(
                name: "direccionid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    linea1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    linea2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigopostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_direccionid",
                table: "AspNetUsers",
                column: "direccionid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Direcciones_direccionid",
                table: "AspNetUsers",
                column: "direccionid",
                principalTable: "Direcciones",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Direcciones_direccionid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_direccionid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "direccionid",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "AspNetUsers",
                newName: "Nombre");
        }
    }
}
