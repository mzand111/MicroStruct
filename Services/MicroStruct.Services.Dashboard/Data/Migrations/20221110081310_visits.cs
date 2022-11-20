using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroStruct.Services.Dashboard.Data.Migrations
{
    /// <inheritdoc />
    public partial class visits : Migration
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
                    { new Guid("ac8dcd84-a2d1-4e92-b54c-e002cf964400"),"Site Visits",true,320},

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
                    { "admin",new Guid("ac8dcd84-a2d1-4e92-b54c-e002cf964400"),null},

              }

          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                               table: "Widget",
                               keyColumn: "ID",
                               keyValues: new object[] { new Guid("ac8dcd84-a2d1-4e92-b54c-e002cf964400") });
        }
    }
}
