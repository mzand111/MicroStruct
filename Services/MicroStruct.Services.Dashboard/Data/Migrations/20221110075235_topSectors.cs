using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroStruct.Services.Dashboard.Data.Migrations
{
    /// <inheritdoc />
    public partial class topSectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Widgets", new string[]
              {
                    "ID",
                    "Name",
                    "Enabled",
                    "DefaultHeight"

              }
              , new object[,]
              {
                    { new Guid("98a06b79-102c-49ad-be92-fd8b484b2f17"),"Top Sectors",true,410},

              }

          );
            migrationBuilder.InsertData("WidgetAccesses", new string[]
              {
                    "RoleName",
                    "WidgetID",
                    "DepartmentID",

              }
              , new object[,]
              {
                    { "admin",new Guid("98a06b79-102c-49ad-be92-fd8b484b2f17"),null},

              }

          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                               table: "Widget",
                               keyColumn: "ID",
                               keyValues: new object[] { new Guid("98a06b79-102c-49ad-be92-fd8b484b2f17") });
        }
    }
}
