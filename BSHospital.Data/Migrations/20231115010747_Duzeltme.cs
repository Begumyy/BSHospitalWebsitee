using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSHospital.Data.Migrations
{
    /// <inheritdoc />
    public partial class Duzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "Patients",
                newName: "PatientName");

            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "Doctors",
                newName: "DoctorName");

            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "Departments",
                newName: "DepartmantName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "Patients",
                newName: "NameSurname");

            migrationBuilder.RenameColumn(
                name: "DoctorName",
                table: "Doctors",
                newName: "NameSurname");

            migrationBuilder.RenameColumn(
                name: "DepartmantName",
                table: "Departments",
                newName: "NameSurname");

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
