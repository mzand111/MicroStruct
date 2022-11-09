using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroStruct.Services.Dashboard.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    DefaultHeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WindgetInstances",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WidgetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContainerStructureID = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ContainerID = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Order = table.Column<byte>(type: "tinyint", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Height = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Config = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindgetInstances", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WidgetAccesses",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    WidgetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetAccesses", x => new { x.WidgetID, x.RoleName });
                    table.ForeignKey(
                        name: "FK_WidgetAccesses_Widgets_WidgetID",
                        column: x => x.WidgetID,
                        principalTable: "Widgets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WidgetAccesses");

            migrationBuilder.DropTable(
                name: "WindgetInstances");

            migrationBuilder.DropTable(
                name: "Widgets");
        }
    }
}
