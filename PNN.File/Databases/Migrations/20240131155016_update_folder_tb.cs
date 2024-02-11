using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNN.File.Databases.Migrations
{
    public partial class update_folder_tb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanDetectTracks",
                table: "MediaFolders");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MediaFolders");

            migrationBuilder.DropColumn(
                name: "IncludePath",
                table: "MediaFolders");

            migrationBuilder.DropColumn(
                name: "MetaData",
                table: "MediaFolders");

            migrationBuilder.DropColumn(
                name: "ResKey",
                table: "MediaFolders");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "MediaFolders");

            migrationBuilder.DropColumn(
                name: "TreePath",
                table: "MediaFolders");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "MediaFiles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "MimeType",
                table: "MediaFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MetaData",
                table: "MediaFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MediaType",
                table: "MediaFiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "MediaStorageId",
                table: "MediaFiles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FixedSize",
                table: "MediaFiles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanDetectTracks",
                table: "MediaFolders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MediaFolders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IncludePath",
                table: "MediaFolders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaData",
                table: "MediaFolders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResKey",
                table: "MediaFolders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "MediaFolders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreePath",
                table: "MediaFolders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "MediaFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MimeType",
                table: "MediaFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetaData",
                table: "MediaFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MediaType",
                table: "MediaFiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MediaStorageId",
                table: "MediaFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FixedSize",
                table: "MediaFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
