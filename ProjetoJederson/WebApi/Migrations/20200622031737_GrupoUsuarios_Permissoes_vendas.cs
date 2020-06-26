using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class GrupoUsuarios_Permissoes_vendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRUPO_USUARIO_PERMISSAO",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grupoUsuarioId = table.Column<long>(nullable: false),
                    permissaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPO_USUARIO_PERMISSAO", x => x.id);
                    table.ForeignKey(
                        name: "FK_GRUPO_USUARIO_PERMISSAO_GRUPO_USUARIO_grupoUsuarioId",
                        column: x => x.grupoUsuarioId,
                        principalTable: "GRUPO_USUARIO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRUPO_USUARIO_PERMISSAO_PERMISSAO_permissaoId",
                        column: x => x.permissaoId,
                        principalTable: "PERMISSAO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_PERMISSAO",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioId = table.Column<long>(nullable: false),
                    permissaoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_PERMISSAO", x => x.id);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERMISSAO_PERMISSAO_permissaoId",
                        column: x => x.permissaoId,
                        principalTable: "PERMISSAO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERMISSAO_USUARIOS_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS_GRUPO_USUARIOS",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioId = table.Column<long>(nullable: false),
                    grupoUsuarioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS_GRUPO_USUARIOS", x => x.id);
                    table.ForeignKey(
                        name: "FK_USUARIOS_GRUPO_USUARIOS_GRUPO_USUARIO_grupoUsuarioId",
                        column: x => x.grupoUsuarioId,
                        principalTable: "GRUPO_USUARIO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOS_GRUPO_USUARIOS_USUARIOS_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENDAS",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataVenda = table.Column<DateTime>(nullable: false),
                    clienteId = table.Column<long>(nullable: false),
                    valorTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS", x => x.id);
                    table.ForeignKey(
                        name: "FK_VENDAS_CLIENTES_clienteId",
                        column: x => x.clienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITENS_VENDA",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendaId = table.Column<long>(nullable: false),
                    casquinhaId = table.Column<long>(nullable: false),
                    valorCasquinha = table.Column<decimal>(nullable: false),
                    saborId = table.Column<long>(nullable: false),
                    valorSabor = table.Column<decimal>(nullable: false),
                    acompanhamentosId = table.Column<long>(nullable: false),
                    valorAcompanhamentos = table.Column<decimal>(nullable: false),
                    adicionalId = table.Column<long>(nullable: false),
                    valorAdicional = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENS_VENDA", x => x.id);
                    table.ForeignKey(
                        name: "FK_ITENS_VENDA_ACOMPANHAMENTOS_acompanhamentosId",
                        column: x => x.acompanhamentosId,
                        principalTable: "ACOMPANHAMENTOS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_VENDA_ADICIONAIS_adicionalId",
                        column: x => x.adicionalId,
                        principalTable: "ADICIONAIS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_VENDA_CASQUINHAS_casquinhaId",
                        column: x => x.casquinhaId,
                        principalTable: "CASQUINHAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_VENDA_SABORES_saborId",
                        column: x => x.saborId,
                        principalTable: "SABORES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENS_VENDA_VENDAS_vendaId",
                        column: x => x.vendaId,
                        principalTable: "VENDAS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRUPO_USUARIO_PERMISSAO_grupoUsuarioId",
                table: "GRUPO_USUARIO_PERMISSAO",
                column: "grupoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPO_USUARIO_PERMISSAO_permissaoId",
                table: "GRUPO_USUARIO_PERMISSAO",
                column: "permissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_VENDA_acompanhamentosId",
                table: "ITENS_VENDA",
                column: "acompanhamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_VENDA_adicionalId",
                table: "ITENS_VENDA",
                column: "adicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_VENDA_casquinhaId",
                table: "ITENS_VENDA",
                column: "casquinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_VENDA_saborId",
                table: "ITENS_VENDA",
                column: "saborId");

            migrationBuilder.CreateIndex(
                name: "IX_ITENS_VENDA_vendaId",
                table: "ITENS_VENDA",
                column: "vendaId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PERMISSAO_permissaoId",
                table: "USUARIO_PERMISSAO",
                column: "permissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PERMISSAO_usuarioId",
                table: "USUARIO_PERMISSAO",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_GRUPO_USUARIOS_grupoUsuarioId",
                table: "USUARIOS_GRUPO_USUARIOS",
                column: "grupoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_GRUPO_USUARIOS_usuarioId",
                table: "USUARIOS_GRUPO_USUARIOS",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_clienteId",
                table: "VENDAS",
                column: "clienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRUPO_USUARIO_PERMISSAO");

            migrationBuilder.DropTable(
                name: "ITENS_VENDA");

            migrationBuilder.DropTable(
                name: "USUARIO_PERMISSAO");

            migrationBuilder.DropTable(
                name: "USUARIOS_GRUPO_USUARIOS");

            migrationBuilder.DropTable(
                name: "VENDAS");
        }
    }
}
