using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroStruct.Services.Dashboard.Data.Migrations
{
    /// <inheritdoc />
    public partial class amountBySectors : Migration
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
                    { new Guid("6adf8713-cc80-492f-9d83-ebf747e689f0"),"Payed Amount by Sectors",true,410},

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
                    { "admin",new Guid("6adf8713-cc80-492f-9d83-ebf747e689f0"),null},

              }

          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                               table: "Widget",
                               keyColumn: "ID",
                               keyValues: new object[] { new Guid("6adf8713-cc80-492f-9d83-ebf747e689f0") });
        }
    }
}
