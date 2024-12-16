using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentsApp.Backend.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeInvestments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Baja = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInvestments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investmetns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tikcker = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImporteInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImporteFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTypeInvestment = table.Column<long>(type: "bigint", nullable: false),
                    Baja = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investmetns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investmetns_TypeInvestments_IdTypeInvestment",
                        column: x => x.IdTypeInvestment,
                        principalTable: "TypeInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investmetns_IdTypeInvestment",
                table: "Investmetns",
                column: "IdTypeInvestment");

            migrationBuilder.CreateIndex(
                name: "IX_Investmetns_Tikcker",
                table: "Investmetns",
                column: "Tikcker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investmetns");

            migrationBuilder.DropTable(
                name: "TypeInvestments");
        }
    }
}
