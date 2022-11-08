using MicroStruct.Services.Dashboard.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroStruct.Services.Dashboard.Data.Entities
{
    [Table("WidgetAccess")]
    public class WidgetAccessEntity:WidgetAccess
    {
        public string RoleName { get; set; }

        public Guid WidgetID { get; set; }

        public WidgetEntity WidgetEntity { get; set; }

        [NotMapped]
        public override WidgetAccessKey ID
        {
            get
            {
                return new WidgetAccessKey()
                {
                    RoleName = this.RoleName,
                    WidgetID = this.WidgetID
                };
            }
            set
            {
                this.WidgetID = value.WidgetID;
                this.RoleName = value.RoleName;
            }
        }
    }
}
