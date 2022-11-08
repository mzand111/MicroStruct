using MZBase.Domain;

namespace MicroStruct.Services.Dashboard.Domain.Model
{
    public class WidgetInstance:Auditable<Guid>
    {
        public string Title { get; set; }

        public Guid WidgetID { get; set; }

        public string UserName { get; set; }

        public string ContainerStructureID { get; set; }

        public string ContainerID { get; set; }

        public byte Order { get; set; }

        public string? Width { get; set; }

        public string Height { get; set; }

        public bool Visible { get; set; }
       
        public string? Config { get; set; }
    }
}
