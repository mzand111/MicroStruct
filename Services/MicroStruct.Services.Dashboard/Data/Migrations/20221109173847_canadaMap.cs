using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroStruct.Services.Dashboard.Data.Migrations
{
    /// <inheritdoc />
    public partial class canadaMap : Migration
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
                    { new Guid("c9d86403-f653-4645-a61a-353dc9e20053"),"Canada Geographical Map Distribution",true,400},

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
                    { "admin",new Guid("c9d86403-f653-4645-a61a-353dc9e20053"),null},

              }

          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                               table: "Widget",
                               keyColumn: "ID",
                               keyValues: new object[] { new Guid("c9d86403-f653-4645-a61a-353dc9e20053") });
        }
    }
}
