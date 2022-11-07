using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroStruct.Services.WorkflowApi.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentLocals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLocals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestLocals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyNationalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramTypeID = table.Column<int>(type: "int", nullable: false),
                    WorkflowInstanceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentSUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectDepartmentExpertUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkflowStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentStep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStepFormalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStepDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentActivityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkflowFinishTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    InThisStateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FacilityRequestTotalState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastMidificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Financial_WorkflowInstanceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Financial_WorkflowStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Financial_CurrentActivityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Financial_InThisStateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Financial_CurrentStep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Financial_CurrentStepFormalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Financial_CurrentStepDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Financial_FacilityRequestTotalState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Financial_WorkflowFinishTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgramTypeKindID = table.Column<byte>(type: "tinyint", nullable: false),
                    RequestedAmount = table.Column<double>(type: "float", nullable: true),
                    AcceptedAmount = table.Column<double>(type: "float", nullable: true),
                    AcceptedRate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestLocals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleLocals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLocals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiddenAction = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestPermissions",
                columns: table => new
                {
                    LoanRequestLocalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleLocalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateActionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestPermissions", x => new { x.StateActionID, x.LoanRequestLocalID, x.RoleLocalID });
                    table.ForeignKey(
                        name: "FK_LoanRequestPermissions_LoanRequestLocals_LoanRequestLocalID",
                        column: x => x.LoanRequestLocalID,
                        principalTable: "LoanRequestLocals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequestPermissions_RoleLocals_RoleLocalID",
                        column: x => x.RoleLocalID,
                        principalTable: "RoleLocals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequestPermissions_StateActions_StateActionID",
                        column: x => x.StateActionID,
                        principalTable: "StateActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestPermissions_LoanRequestLocalID",
                table: "LoanRequestPermissions",
                column: "LoanRequestLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestPermissions_RoleLocalID",
                table: "LoanRequestPermissions",
                column: "RoleLocalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLocals");

            migrationBuilder.DropTable(
                name: "LoanRequestPermissions");

            migrationBuilder.DropTable(
                name: "LoanRequestLocals");

            migrationBuilder.DropTable(
                name: "RoleLocals");

            migrationBuilder.DropTable(
                name: "StateActions");
        }
    }
}
