using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaFile.Databases.Migrations;
public partial class AddColumn : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<long>(
            name: "Size",
            table: "MediaFiles",
            type: "bigint",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer");

        migrationBuilder.AddColumn<string>(
            name: "MediaType",
            table: "MediaFiles",
            type: "text",
            nullable: false,
            defaultValue: "");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "MediaType",
            table: "MediaFiles");

        migrationBuilder.AlterColumn<int>(
            name: "Size",
            table: "MediaFiles",
            type: "integer",
            nullable: false,
            oldClrType: typeof(long),
            oldType: "bigint");
    }
}
