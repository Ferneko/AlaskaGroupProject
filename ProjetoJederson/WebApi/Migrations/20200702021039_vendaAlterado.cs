using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class vendaAlterado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_CLIENTES_clienteId",
                table: "VENDAS");

            migrationBuilder.DropIndex(
                name: "IX_VENDAS_clienteId",
                table: "VENDAS");

            migrationBuilder.DropColumn(
                name: "clienteId",
                table: "VENDAS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "clienteId",
                table: "VENDAS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_clienteId",
                table: "VENDAS",
                column: "clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_CLIENTES_clienteId",
                table: "VENDAS",
                column: "clienteId",
                principalTable: "CLIENTES",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
