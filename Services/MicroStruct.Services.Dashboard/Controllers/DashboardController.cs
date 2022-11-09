using MicroStruct.Services.Dashboard.Controllers.Dto;
using MicroStruct.Services.Dashboard.Service;
using MicroStruct.Services.Dashboard.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MZBase.Infrastructure;
using System.ComponentModel;

namespace MicroStruct.Services.Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : MicroStructBaseApiController
    {
        private readonly DashboardService _service;
        private readonly IDateTimeProviderService _dateTimeProvider;

        public DashboardController(DashboardService service, IDateTimeProviderService dateTimeProvider)
        {
            _service = service;
            _dateTimeProvider = dateTimeProvider;
        }

        [HttpGet("GetMyContainerStructureWidgetInstanceList")]
        public async Task<ActionResult<List<WidgetInstanceDto>>> GetMyContainerStructureWidgetInstanceList(string containerStructureID)
        => Ok(await _service.GetUserContainerStructureWidgetInstanceList(containerStructureID, UserName, LoweredUserRoleNames.FirstOrDefault()));

        [HttpPost("AddWidgetInstanceToMyContainer")]
        public async Task<ActionResult> AddWidgetInstanceToMyContainer(string containerStructureUniqID, string containerID, Guid widgetID)
        {
            await _service.AddWidgetInstanceToUserContainer(containerStructureUniqID, containerID, widgetID, UserName, LoweredUserRoleNames.FirstOrDefault());
            return Ok();
        }
        [HttpPost("SaveLayout")]
        public async Task<ActionResult> SaveLayout(ContainerStructureWidgets containerStructureWidgets)
        {
            await _service.SaveLayout(containerStructureWidgets, UserName, LoweredUserRoleNames.FirstOrDefault());
            return Ok();
        }
        [HttpPost("SaveWidgetInstanceSettings")]
        public async Task<ActionResult> SaveWidgetInstanceSettings(Guid widgetInstanceID, string title, int height)
        {
            await _service.SaveWidgetInstanceSettings( UserName, widgetInstanceID, title,height);
            return Ok();
        }
        [HttpPost("SaveWidgetInstanceConfig")]
        public async Task<ActionResult> SaveWidgetInstanceConfig(Guid widgetInstanceID, string configString)
        {
            await _service.SaveWidgetInstanceConfig(UserName, widgetInstanceID, configString);
            return Ok();
        }
        [HttpGet("GetMyAvailableWidgets")]
        public async Task<ActionResult<List<WidgetDto>>> GetMyAvailableWidgets()
       => Ok(await _service.GetUserAvailableWidgets(LoweredUserRoleNames.FirstOrDefault()));
    }
}
