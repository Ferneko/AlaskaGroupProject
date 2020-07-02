using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class vendaAlterado11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_VENDA_ACOMPANHAMENTOS_acompanhamentosId",
                table: "ITENS_VENDA");

            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_VENDA_ADICIONAIS_adicionalId",
                table: "ITENS_VENDA");

            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_VENDA_CASQUINHAS_casquinhaId",
                table: "ITENS_VENDA");

            migrationBuilder.DropForeignKey(
                name: "FK_ITENS_VENDA_SABORES_saborId",
                table: "ITENS_VENDA");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_VENDA_acompanhamentosId",
                table: "ITENS_VENDA");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_VENDA_adicionalId",
                table: "ITENS_VENDA");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_VENDA_casquinhaId",
                table: "ITENS_VENDA");

            migrationBuilder.DropIndex(
                name: "IX_ITENS_VENDA_saborId",
                table: "ITENS_VENDA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_VENDA_ACOMPANHAMENTOS_acompanhamentosId",
                table: "ITENS_VENDA",
                column: "acompanhamentosId",
                principalTable: "ACOMPANHAMENTOS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_VENDA_ADICIONAIS_adicionalId",
                table: "ITENS_VENDA",
                column: "adicionalId",
                principalTable: "ADICIONAIS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_VENDA_CASQUINHAS_casquinhaId",
                table: "ITENS_VENDA",
                column: "casquinhaId",
                principalTable: "CASQUINHAS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITENS_VENDA_SABORES_saborId",
                table: "ITENS_VENDA",
                column: "saborId",
                principalTable: "SABORES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
