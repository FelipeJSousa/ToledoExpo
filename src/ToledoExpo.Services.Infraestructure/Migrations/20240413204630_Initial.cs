using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ToledoExpo.Services.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "atendimento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cliente = table.Column<long>(type: "bigint", nullable: false),
                    Atendente = table.Column<long>(type: "bigint", nullable: false),
                    data_chegada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_inicio_atendimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_fim_atendimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atendimento", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estabelecimento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    DataCricao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Proprietario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estabelecimento", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    velocidade_movimento = table.Column<double>(type: "double", nullable: false),
                    capacidade_cognitiva = table.Column<double>(type: "double", nullable: false),
                    Ativo = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_atendimento_Id",
                        column: x => x.Id,
                        principalTable: "atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "atendente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "longtext", nullable: true),
                    estabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    tempo_atend_minimo = table.Column<double>(type: "double", nullable: false),
                    Ativo = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atendente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_atendente_atendimento_Id",
                        column: x => x.Id,
                        principalTable: "atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_atendente_estabelecimento_estabelecimentoId",
                        column: x => x.estabelecimentoId,
                        principalTable: "estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "estabelecimento",
                columns: new[] { "Id", "Ativo", "DataCricao", "Descricao", "Nome", "Proprietario" },
                values: new object[] { 1L, "S", new DateTime(2024, 4, 13, 17, 46, 30, 28, DateTimeKind.Local).AddTicks(9194), "Descrição de teste.", "Estabelecimento 1", "Felipe Sousa" });

            migrationBuilder.CreateIndex(
                name: "IX_atendente_estabelecimentoId",
                table: "atendente",
                column: "estabelecimentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atendente");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "estabelecimento");

            migrationBuilder.DropTable(
                name: "atendimento");
        }
    }
}
