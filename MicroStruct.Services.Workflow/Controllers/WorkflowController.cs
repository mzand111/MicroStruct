using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicroStruct.Services.Workflow.Models.Dtos;

namespace MicroStruct.Services.Workflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<WorkflowDto> GetAll()
        {
            return new List<WorkflowDto>()
            {
                new WorkflowDto()
                {
                    Id = Guid.NewGuid(),
                    Name ="چرخه اول"
                },
                new WorkflowDto()
                {
                    Id=Guid.NewGuid(),
                    Name =  "چرخه دوم"
                }
            };
        }
    }
}
