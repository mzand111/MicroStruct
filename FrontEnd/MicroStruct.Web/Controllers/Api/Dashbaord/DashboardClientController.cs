using MicroStruct.Web.Controllers.API.Base;

using MicroStruct.Web.HttpServices.Dashboard;
using MicroStruct.Web.HttpServices.Dashboard.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicroStruct.Web.HttpServices.Dashboard;

namespace MicroStruct.Web.Controllers.API.Dashbaord
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardClientController : MicroServiceWrapperController<IDashboardHttpService>
    {
        private readonly IDashboardHttpService _dashboardService;

        /// <summary>
        /// Extra log codes:
        /// 10:GetMyAvailableWidgets
        /// 11:GetMyContainerStructureWidgetInstanceList
        /// </summary>


        public DashboardClientController(ILogger<IDashboardHttpService> logger, IDashboardHttpService dashboardService, IHostEnvironment hostEnvironment) : base(logger, hostEnvironment, 2000)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [Route("GetMyAvailableWidgets")]        
        public async Task<ActionResult<List<WidgetDto>>> GetMyAvailableWidgets()
        {
            LogMultipleGet(LogPurposeType.Access, "GetMyAvailableWidgets", null, null, 10);
            var b = await _dashboardService.GetMyAvailableWidgets();
            LogMultipleGet(LogPurposeType.Success, "GetMyAvailableWidgets", null, null, 10);
            return Ok(b);
        }
        [HttpGet]
        [Route("GetMyContainerStructureWidgetInstanceList")]        
        public async Task<ActionResult<List<WidgetInstanceDto>>> GetMyContainerStructureWidgetInstanceList(string containerStructureID)
        {
            LogMultipleGet(LogPurposeType.Access, "GetMyContainerStructureWidgetInstanceList", null, null, 11);
            var b = await _dashboardService.GetMyContainerStructureWidgetInstanceList(containerStructureID);
            LogMultipleGet(LogPurposeType.Success, "GetMyContainerStructureWidgetInstanceList", null, null, 11);
            return Ok(b);
        }

        [HttpPost("AddWidgetInstanceToMyContainer")]
        public async Task<IActionResult> AddWidgetInstanceToMyContainer(string containerStructureUniqID, string containerID, Guid widgetID)
        {
            LogPost(LogPurposeType.Access, "AddWidgetInstanceToMyContainer");           
            try
            {
                 await _dashboardService.AddWidgetInstanceToMyContainer(containerStructureUniqID,containerID,widgetID);
                LogPost(LogPurposeType.Success);
                return Ok();
            }
            catch (Exception ex)
            {
                LogPostFailure(ex);
                return GetActionByException(ex);
            }
        }

        [HttpPost("SaveLayout")]
        public async Task<IActionResult> SaveLayout(ContainerStructureWidgets cw)
        {
            LogPost(LogPurposeType.Access, "SaveLayout");
            try
            {
                await _dashboardService.SaveLayout(cw);
                LogPost(LogPurposeType.Success);
                return Ok();
            }
            catch (Exception ex)
            {
                LogPostFailure(ex);
                return GetActionByException(ex);
            }
        }
        [HttpPost("SaveWidgetInstanceConfig")]
        public async Task<IActionResult> SaveWidgetInstanceConfig(Guid widgetInstanceID, string configString)
        {
            LogPost(LogPurposeType.Access, "SaveWidgetInstanceConfig");
            try
            {
                await _dashboardService.SaveWidgetInstanceConfig( widgetInstanceID,  configString);
                LogPost(LogPurposeType.Success);
                return Ok();
            }
            catch (Exception ex)
            {
                LogPostFailure(ex);
                return GetActionByException(ex);
            }
        }
        [HttpPost("SaveWidgetInstanceSettings")]
        public async Task<IActionResult> SaveWidgetInstanceSettings(Guid widgetInstanceID, string title, int height)
        {
            LogPost(LogPurposeType.Access, "SaveWidgetInstanceConfig");
            try
            {
                await _dashboardService.SaveWidgetInstanceSettings(widgetInstanceID, title,height);
                LogPost(LogPurposeType.Success);
                return Ok();
            }
            catch (Exception ex)
            {
                LogPostFailure(ex);
                return GetActionByException(ex);
            }
        }
    }
}
