
namespace MicroStruct.Web.HttpServices.Dashboard.Dto
{
    public class WidgetInstanceDto
    {
        public WidgetInstanceDto()
        {

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
