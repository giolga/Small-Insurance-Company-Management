using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Small_Insurance_Company_Management_Program.Migrations
{
    /// <inheritdoc />
    public partial class InsuranceName_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "InsuranceProducts",
                newName: "InsuranceName");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsuranceName",
                table: "InsuranceProducts",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InsuranceProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
