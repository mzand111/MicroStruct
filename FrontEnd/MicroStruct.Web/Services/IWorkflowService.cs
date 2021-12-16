using MicroStruct.Web.Services.ModelDtos;

namespace MicroStruct.Web.Services
{
    public interface IWorkflowService
    {
        Task<IEnumerable<WorkflowDto>> GetAll();
    }
}
