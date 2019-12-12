using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scripts",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    episode = table.Column<int>(nullable: false),
                    episode_name = table.Column<string>(nullable: true),
                    segment = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    actor = table.Column<string>(nullable: true),
                    character = table.Column<string>(nullable: true),
                    detail = table.Column<string>(maxLength: 1000, nullable: true),
                    record_date = table.Column<DateTime>(nullable: true),
                    series = table.Column<string>(nullable: true),
                    transmission_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scripts", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scripts");
        }
    }
}
