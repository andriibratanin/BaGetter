using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaGetter.Database.MySql.Migrations
{
    public partial class Initial : Migration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1861:Avoid constant arrays as arguments", Justification = "Generated and only runs once.")]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Since Latin1 is no longer the default, we have to add it here in, so fresh migrations still run.
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Authors = table.Column<string>(maxLength: 4000, nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Downloads = table.Column<long>(nullable: false),
                    HasReadme = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(maxLength: 20, nullable: true),
                    Listed = table.Column<bool>(nullable: false),
                    MinClientVersion = table.Column<string>(maxLength: 44, nullable: true),
                    Published = table.Column<DateTime>(nullable: false),
                    RequireLicenseAcceptance = table.Column<bool>(nullable: false),
                    Summary = table.Column<string>(maxLength: 4000, nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    IconUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    LicenseUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    ProjectUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    RepositoryUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    RepositoryType = table.Column<string>(maxLength: 100, nullable: true),
                    Tags = table.Column<string>(maxLength: 4000, nullable: true),
                    RowVersion = table.Column<DateTime>(rowVersion: true, nullable: true),
                    Version = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "PackageDependencies",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(maxLength: 128, nullable: true),
                    VersionRange = table.Column<string>(maxLength: 256, nullable: true),
                    TargetFramework = table.Column<string>(maxLength: 256, nullable: true),
                    PackageKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDependencies", x => x.Key);
                    table.ForeignKey(
                        name: "FK_PackageDependencies_Packages_PackageKey",
                        column: x => x.PackageKey,
                        principalTable: "Packages",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageDependencies_PackageKey",
                table: "PackageDependencies",
                column: "PackageKey");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Id",
                table: "Packages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Id_Version",
                table: "Packages",
                columns: new[] { "Id", "Version" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageDependencies");

            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
