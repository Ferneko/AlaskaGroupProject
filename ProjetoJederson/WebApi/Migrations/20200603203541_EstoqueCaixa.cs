using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class EstoqueCaixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAIXA",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(nullable: false),
                    tipoMovimentacao = table.Column<int>(nullable: false),
                    valor = table.Column<decimal>(nullable: false),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAIXA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ESTOQUE",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(nullable: false),
                    tipoMovimentacao = table.Column<int>(nullable: false),
                    casquinhaId = table.Column<long>(nullable: false),
                    quantidadeCasquinha = table.Column<decimal>(nullable: false),
                    adicionalId = table.Column<long>(nullable: false),
                    quantidadeAdicional = table.Column<decimal>(nullable: false),
                    acompanhamentoId = table.Column<long>(nullable: false),
                    quantidadeAcompanhamento = table.Column<decimal>(nullable: false),
                    saboresId = table.Column<long>(nullable: false),
                    quantidadeSabores = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTOQUE", x => x.id);
                    table.ForeignKey(
                        name: "FK_ESTOQUE_ACOMPANHAMENTOS_acompanhamentoId",
                        column: x => x.acompanhamentoId,
                        principalTable: "ACOMPANHAMENTOS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESTOQUE_ADICIONAIS_adicionalId",
                        column: x => x.adicionalId,
                        principalTable: "ADICIONAIS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESTOQUE_CASQUINHAS_casquinhaId",
                        column: x => x.casquinhaId,
                        principalTable: "CASQUINHAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ESTOQUE_SABORES_saboresId",
                        column: x => x.saboresId,
                        principalTable: "SABORES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUE_acompanhamentoId",
                table: "ESTOQUE",
                column: "acompanhamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUE_adicionalId",
                table: "ESTOQUE",
                column: "adicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUE_casquinhaId",
                table: "ESTOQUE",
                column: "casquinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ESTOQUE_saboresId",
                table: "ESTOQUE",
                column: "saboresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAIXA");

            migrationBuilder.DropTable(
                name: "ESTOQUE");
        }
    }
}
