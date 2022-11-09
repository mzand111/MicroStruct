using MicroStruct.Services.Dashboard.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroStruct.Services.Dashboard.Data.Entities
{
    [Table("WindgetInstances")]
    public class WidgetInstanceEntity: WidgetInstance
    {
        public WidgetInstanceEntity()
        {

        }
        public WidgetInstanceEntity(WidgetInstance widgetInstance)
        {
            this.Title = widgetInstance.Title;
            this.WidgetID = widgetInstance.WidgetID;
            this.UserName = widgetInstance.UserName;
            this.ContainerID = widgetInstance.ContainerID;
            this.ContainerStructureID = widgetInstance.ContainerStructureID;
            this.Order =  widgetInstance.Order;
            this.ID = widgetInstance.ID;    
            this.Width = widgetInstance.Width;
            this.Height = widgetInstance.Height;
            this.Visible = widgetInstance.Visible;
            this.Config = widgetInstance.Config;
            this.CreationTime = widgetInstance.CreationTime;
            this.CreatedBy= widgetInstance.CreatedBy;
            this.LastModificationTime= widgetInstance.LastModificationTime;
            this.LastModifiedBy = widgetInstance.LastModifiedBy;
        }
    }
}
