using MicroStruct.Services.Dashboard.Domain.Model;

namespace MicroStruct.Services.Dashboard.Controllers.Dto
{
    public class WidgetDto
    {
        public WidgetDto()
        {

        }
        public WidgetDto(Widget widget)
        {
            this.ID = widget.ID;
            this.Name = widget.Name;
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
