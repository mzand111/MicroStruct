using MZBase.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroStruct.Services.Dashboard.Domain.Model
{
    public class WidgetAccess:Model<WidgetAccessKey>
    {
        public Guid? DepartmentID { get; set; }
       
    }

    public struct WidgetAccessKey
    {
        public string RoleName { get; set; }
        public Guid WidgetID { get; set; }
    }
}
