using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeVendas.Migrations
{
    public partial class qinta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedor_VendadorId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "VendadorId",
                table: "Vendas",
                newName: "VendedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_VendadorId",
                table: "Vendas",
                newName: "IX_Vendas_VendedorId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Vendedor",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedor_VendedorId",
                table: "Vendas",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedor_VendedorId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "Vendas",
                newName: "VendadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                newName: "IX_Vendas_VendadorId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Vendedor",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Vendedor",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedor_VendadorId",
                table: "Vendas",
                column: "VendadorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
