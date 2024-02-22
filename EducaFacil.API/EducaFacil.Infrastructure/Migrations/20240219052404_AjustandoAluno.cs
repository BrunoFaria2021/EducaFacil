using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaFacil.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Series_SerieId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_SerieId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SerieId",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_SerieId",
                table: "Alunos",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Series_SerieId",
                table: "Alunos",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
