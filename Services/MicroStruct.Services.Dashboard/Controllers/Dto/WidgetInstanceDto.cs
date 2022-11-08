using MicroStruct.Services.Dashboard.Domain.Model;

namespace MicroStruct.Services.Dashboard.Controllers.Dto
{
    public class WidgetInstanceDto
    {
        public WidgetInstanceDto()
        {

        }

        public WidgetInstanceDto(WidgetInstance wi)
        {
            ID = wi.ID;
            Title = wi.Title;

            WidgetID = wi.WidgetID;
            UserName = wi.UserName;
            ContainerStructureID = wi.ContainerStructureID;
            ContainerID = wi.ContainerID;
            Order = wi.Order;
            Width = wi.Width;
            Height = wi.Height;
            Config = wi.Config;
        }
        public Guid ID { get; set; }

        public string Title { get; set; }

        public Guid WidgetID { get; set; }
        public string UserName { get; set; }
        public string ContainerStructureID { get; set; }
        public string ContainerID { get; set; }
        public byte Order { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Config { get; set; }
    }
}
