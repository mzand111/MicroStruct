using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroStruct.Services.Dashboard.Data.Migrations
{
    /// <inheritdoc />
    public partial class acceptanceFlowStepDelayTimesWidget : Migration
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
                    { new Guid("a5660356-2693-433f-8c66-a29d5c4a887c"),"Average Time In Steps",true,400},

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
                    { "admin",new Guid("a5660356-2693-433f-8c66-a29d5c4a887c"),null},

              }

          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                               table: "Widget",
                               keyColumn: "ID",
                               keyValues: new object[] { new Guid("a5660356-2693-433f-8c66-a29d5c4a887c") });
        }
    }
}
