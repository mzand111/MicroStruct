namespace MicroStruct.Services.WorkflowApi.Models
{
    public class StateAction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HiddenAction { get; set; }
        public string? Description { get; set; }
    }
}
