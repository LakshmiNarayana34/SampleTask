using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InTimeOutTime.Migrations
{
    /// <inheritdoc />
    public partial class EmpUpdateInTimeOutTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeTimeSheets",
                columns: table => new
                {
                    EmpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeTimeSheets", x => new { x.EmpId, x.Date });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeTimeSheets");
        }
    }
}
