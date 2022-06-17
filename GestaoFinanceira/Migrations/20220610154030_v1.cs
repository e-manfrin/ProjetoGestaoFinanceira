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

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DataHora", "Descricao", "Valor" },
                values: new object[] { 1, new DateTime(2022, 6, 10, 12, 40, 30, 268, DateTimeKind.Local).AddTicks(6692), "Pago", 100.0 });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DataHora", "Descricao", "Valor" },
                values: new object[] { 2, new DateTime(2022, 6, 10, 12, 40, 30, 268, DateTimeKind.Local).AddTicks(6709), "Pago", 700.0 });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "DataHora", "Descricao", "Valor" },
                values: new object[] { 3, new DateTime(2022, 6, 10, 12, 40, 30, 268, DateTimeKind.Local).AddTicks(6710), "Pago", 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
