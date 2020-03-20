using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Alaska_db_isabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senha",
                table: "USUARIOS",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "USUARIOS",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "USUARIOS",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "USUARIOS",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "USUARIOS",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "CASQUINHA",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Actives = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASQUINHA", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CASQUINHA");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "USUARIOS",
                newName: "senha");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "USUARIOS",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "USUARIOS",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "USUARIOS",
                newName: "ativo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USUARIOS",
                newName: "id");
        }
    }
}
