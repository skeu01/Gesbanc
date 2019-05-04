using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gesbanc.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoEntidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEntidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    GrupoEntidadId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Poblacion = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    CodPostal = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Estado_Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entidad_GrupoEntidad_GrupoEntidadId",
                        column: x => x.GrupoEntidadId,
                        principalTable: "GrupoEntidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GrupoEntidad",
                columns: new[] { "Id", "Color", "DateCreated", "DateUpdated", "Nombre" },
                values: new object[,]
                {
                    { 1, "Azul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sabadell" },
                    { 2, "Verde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bankia" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "DateCreated", "DateUpdated", "Password", "Username" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "098f6bcd4621d373cade4e832627b4f6", "test" },
                    { 2, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "098f6bcd4621d373cade4e832627b4f6", "test2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_GrupoEntidadId",
                table: "Entidad",
                column: "GrupoEntidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "GrupoEntidad");
        }
    }
}
