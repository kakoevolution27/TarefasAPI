using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId1",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "CategoriaId1",
                table: "Tarefas",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_CategoriaId1",
                table: "Tarefas",
                newName: "IX_Tarefas_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Tarefas",
                newName: "CategoriaId1");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_CategoriaId",
                table: "Tarefas",
                newName: "IX_Tarefas_CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Categorias_CategoriaId1",
                table: "Tarefas",
                column: "CategoriaId1",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
