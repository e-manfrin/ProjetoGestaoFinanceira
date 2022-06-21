using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFinanceira.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    EmailLogin = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioCriacao = table.Column<string>(type: "TEXT", nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DataHora", "Descricao", "Valor" },
                values: new object[] { 1, new DateTime(2022, 6, 21, 11, 52, 18, 414, DateTimeKind.Local).AddTicks(7760), "Pago", 100.0 });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DataHora", "Descricao", "Valor" },
                values: new object[] { 2, new DateTime(2022, 6, 21, 11, 52, 18, 414, DateTimeKind.Local).AddTicks(7781), "Pago", 700.0 });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DataHora", "Descricao", "Valor" },
                values: new object[] { 3, new DateTime(2022, 6, 21, 11, 52, 18, 414, DateTimeKind.Local).AddTicks(7783), "Pago", 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
