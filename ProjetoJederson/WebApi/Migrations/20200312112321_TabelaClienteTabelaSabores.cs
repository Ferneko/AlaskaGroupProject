using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class TabelaClienteTabelaSabores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    cidade = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SABORES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SABORES", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "SABORES");
        }
    }
}
