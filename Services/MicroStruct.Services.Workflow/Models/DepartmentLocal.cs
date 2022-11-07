using System.ComponentModel.DataAnnotations;

namespace MicroStruct.Services.WorkflowApi.Models
{
    public class DepartmentLocal
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
