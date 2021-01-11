using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LDXPS.Data.Migrations
{
    public partial class MigrationCreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VENDEDORES",
                columns: table => new
                {
                    CDVEND = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DSNOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CDTAB = table.Column<int>(type: "int", nullable: false),
                    DTNASC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDEDORES", x => x.CDVEND);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    CDCL = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    DSNOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDTIPO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, defaultValue: "PF"),
                    CDVEND = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DSLIM = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.CDCL);
                    table.ForeignKey(
                        name: "FK_CLIENTES_VENDEDORES_CDVEND",
                        column: x => x.CDVEND,
                        principalTable: "VENDEDORES",
                        principalColumn: "CDVEND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_CDVEND",
                table: "CLIENTES",
                column: "CDVEND");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "VENDEDORES");
        }
    }
}
