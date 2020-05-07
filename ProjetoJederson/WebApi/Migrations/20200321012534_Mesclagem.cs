using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Mesclagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACOMPANHAMENTOS",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imagem = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    valor = table.Column<decimal>(nullable: false),
                    ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACOMPANHAMENTOS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ADICIONAIS",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    valor = table.Column<decimal>(nullable: false),
                    ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADICIONAIS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CASQUINHAS",
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
                    table.PrimaryKey("PK_CASQUINHAS", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACOMPANHAMENTOS");

            migrationBuilder.DropTable(
                name: "ADICIONAIS");

            migrationBuilder.DropTable(
                name: "CASQUINHAS");
        }
    }
}
