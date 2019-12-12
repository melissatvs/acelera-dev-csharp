using Microsoft.EntityFrameworkCore.Migrations;

namespace Codenation.Challenge.Migrations
{
    public partial class codenationz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "user",
                newName: "create_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "submission",
                newName: "create_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "company",
                newName: "create_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "challenge",
                newName: "create_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidate",
                newName: "create_at");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "acceleration",
                newName: "create_at");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "challenge",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "challenge",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "user",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "submission",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "company",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "challenge",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "candidate",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "create_at",
                table: "acceleration",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "slug",
                table: "challenge",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "challenge",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
