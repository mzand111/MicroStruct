using Microsoft.Extensions.Options;
using MicroStruct.Web.Config;
using MicroStruct.Web.Services.ModelDtos;

namespace MicroStruct.Web.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly ILogger<WorkflowService> _logger;
        private readonly IOptions<ServiceUrls> _serviceUrls;

        public WorkflowService(ILogger<WorkflowService> logger, IOptions<ServiceUrls> serviceUrls)
        {
            _logger = logger;
            _serviceUrls = serviceUrls;
        }
        public Task<IEnumerable<WorkflowDto>> GetAll()
        {
            _logger.LogWarning("Logging from service ActionID:{SystemActionId}", 1123);
            return null;
        }
    }
}
