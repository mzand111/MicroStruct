namespace MicroStruct.Services.Dashboard.Controllers.Dto
{
    public class WidgetInfo
    {
        public string ContainerID { get; set; }
        public string? WidgetID { get; set; }
        public string WidgetInstanceID { get; set; }
        public byte Order { get; set; }
        public string? Title { get; set; }
    }
}
