using MicroStruct.Web.Services.ModelDtos;

namespace MicroStruct.Web.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly ILogger<WorkflowService> _logger;
        public WorkflowService(ILogger<WorkflowService> logger)
        {
            _logger = logger;
        }
        public Task<IEnumerable<WorkflowDto>> GetAll()
        {
            _logger.LogWarning("Logging from service ActionID:{SystemActionId}", 1123);
            return null;
        }
    }
}
