using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogService.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalogSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Faction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BaseSvgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBaseConcept = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "defaultLayerGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_defaultLayerGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_defaultLayerGroups_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModelParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SvgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LayerOrder = table.Column<int>(type: "int", nullable: false),
                    isOptional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelParts_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "partCompatibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourcePartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompatibleWithPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partCompatibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_partCompatibilities_ModelParts_CompatibleWithPartId",
                        column: x => x.CompatibleWithPartId,
                        principalTable: "ModelParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partCompatibilities_ModelParts_SourcePartId",
                        column: x => x.SourcePartId,
                        principalTable: "ModelParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partCompatibilities_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_defaultLayerGroups_ModelId",
                table: "defaultLayerGroups",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelParts_ModelId",
                table: "ModelParts",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_partCompatibilities_CompatibleWithPartId",
                table: "partCompatibilities",
                column: "CompatibleWithPartId");

            migrationBuilder.CreateIndex(
                name: "IX_partCompatibilities_ModelId",
                table: "partCompatibilities",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_partCompatibilities_SourcePartId",
                table: "partCompatibilities",
                column: "SourcePartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "defaultLayerGroups");

            migrationBuilder.DropTable(
                name: "partCompatibilities");

            migrationBuilder.DropTable(
                name: "ModelParts");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
