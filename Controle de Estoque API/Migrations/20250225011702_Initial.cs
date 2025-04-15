using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_de_Estoque_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Localizacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Grau_Importancia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantidade_Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompatibilidadePecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PecaId = table.Column<int>(type: "int", nullable: false),
                    PecaCompativelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatibilidadePecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompatibilidadePecas_Pecas_PecaCompativelId",
                        column: x => x.PecaCompativelId,
                        principalTable: "Pecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompatibilidadePecas_Pecas_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Pecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExemplarPeca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorPago = table.Column<double>(type: "double", nullable: false),
                    EmEstoque = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CodigoVendedor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PecaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExemplarPeca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExemplarPeca_Pecas_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Pecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompraPeca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodigoPedido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVendedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraPeca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraPeca_Vendedor_IdVendedor",
                        column: x => x.IdVendedor,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PecaVendida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataVenda = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NomeCliente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoOS = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExemplarPecaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecaVendida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PecaVendida_ExemplarPeca_ExemplarPecaId",
                        column: x => x.ExemplarPecaId,
                        principalTable: "ExemplarPeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PecasCompradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoPecaVendedor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    IdCompraPecas = table.Column<int>(type: "int", nullable: false),
                    IdExemplarPeca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecasCompradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PecasCompradas_CompraPeca_IdCompraPecas",
                        column: x => x.IdCompraPecas,
                        principalTable: "CompraPeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PecasCompradas_ExemplarPeca_IdExemplarPeca",
                        column: x => x.IdExemplarPeca,
                        principalTable: "ExemplarPeca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilidadePecas_PecaCompativelId",
                table: "CompatibilidadePecas",
                column: "PecaCompativelId");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilidadePecas_PecaId",
                table: "CompatibilidadePecas",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraPeca_IdVendedor",
                table: "CompraPeca",
                column: "IdVendedor");

            migrationBuilder.CreateIndex(
                name: "IX_ExemplarPeca_PecaId",
                table: "ExemplarPeca",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_PecasCompradas_IdCompraPecas",
                table: "PecasCompradas",
                column: "IdCompraPecas");

            migrationBuilder.CreateIndex(
                name: "IX_PecasCompradas_IdExemplarPeca",
                table: "PecasCompradas",
                column: "IdExemplarPeca");

            migrationBuilder.CreateIndex(
                name: "IX_PecaVendida_ExemplarPecaId",
                table: "PecaVendida",
                column: "ExemplarPecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompatibilidadePecas");

            migrationBuilder.DropTable(
                name: "PecasCompradas");

            migrationBuilder.DropTable(
                name: "PecaVendida");

            migrationBuilder.DropTable(
                name: "CompraPeca");

            migrationBuilder.DropTable(
                name: "ExemplarPeca");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "Pecas");
        }
    }
}
