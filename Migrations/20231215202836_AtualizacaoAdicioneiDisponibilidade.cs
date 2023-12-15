using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace At_C__2023.Migrations
{
    public partial class AtualizacaoAdicioneiDisponibilidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Disponivel",
                table: "Flor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Flor");
        }
    }
}
