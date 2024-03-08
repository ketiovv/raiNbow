using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaiNbow.Core.Storage.Migrations
{
    /// <inheritdoc />
    public partial class FieldType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "data",
                table: "FieldType",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "CSharpTypeName",
                schema: "data",
                table: "FieldType",
                newName: "FieldName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeName",
                schema: "data",
                table: "FieldType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FieldName",
                schema: "data",
                table: "FieldType",
                newName: "CSharpTypeName");
        }
    }
}
