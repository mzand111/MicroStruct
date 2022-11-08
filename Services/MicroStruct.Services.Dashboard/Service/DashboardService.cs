using MicroStruct.Services.Dashboard.Controllers.Dto;
using MicroStruct.Services.Dashboard.Domain.Model;
using MicroStruct.Services.Dashboard.Infrastructure.UnitOfWork;
using MZBase.Infrastructure;
using MZBase.Infrastructure.Service;
using System.Security.Cryptography;

namespace MicroStruct.Services.Dashboard.Service
{
    public class DashboardService : BusinessService<DashboardService>
    {
        private readonly IDashboardUnitOfWork _dashboardUnitOfWork;
        private readonly WidgetInstanceService _widgetInstanceService;
        private readonly IDateTimeProviderService _dateTimeProviderService;

        public DashboardService(ILogger<DashboardService> logger, IDashboardUnitOfWork dashboardUnitOfWork, WidgetInstanceService widgetInstanceService,IDateTimeProviderService dateTimeProviderService) : base(logger)
        {
            _dashboardUnitOfWork = dashboardUnitOfWork;
            _widgetInstanceService = widgetInstanceService;
            _dateTimeProviderService = dateTimeProviderService;
        }
        public async Task<List<WidgetInstanceDto>> GetUserContainerStructureWidgetInstanceList(string containerStructureID, string userName, string userRoleName)
        {
            var items = await _dashboardUnitOfWork.WidgetInstances.GetUserContainerStructureWidgetInstanceListAsync(userName, containerStructureID);
            var validWidgetIds = (await _dashboardUnitOfWork.WidgetAccesses.GetRoleWidgets(userRoleName)).Select(uu => uu.ID).ToList();
            return items.Where(uu => validWidgetIds.Contains(uu.WidgetID)).Select(uu => new WidgetInstanceDto(uu)).ToList();
        }
        public async Task<List<WidgetInstanceDto>> GetDefaultContainerStructureWidgetInstanceList(string containerStructureID, string userRoleName)
        {
            //ToDo
            return null;
        }
        public async Task AddWidgetInstanceToUserContainer(string ContainerStructureUniqID, string ContainerID, Guid widgetID, string userName, string userRoleName)
        {
            var validWidgets = await _dashboardUnitOfWork.WidgetAccesses.GetRoleWidgets(userRoleName);
            var widget = validWidgets.FirstOrDefault(uu => uu.ID == widgetID);
            if (widget == null)
            {
                throw new InvalidProgramException("The widget does not exists or is not related to the user's role");
            }
            int lastU = ContainerID.LastIndexOf('_');
            var ff = _dateTimeProviderService.GetNow();
            WidgetInstance win = new WidgetInstance
            {
                ID = Guid.NewGuid(),
                ContainerStructureID = ContainerStructureUniqID,
                WidgetID = widgetID,
                Order = 200,
                UserName = userName,
                Title = widget.Name,
                Height=widget.DefaultHeight+"px",
                Visible = true,
                ContainerID = ContainerID.Substring(lastU + 1, ContainerID.Length - (lastU + 1)),
                CreatedBy=userName,
                LastModifiedBy=userName,
                CreationTime=ff, 
                LastModificationTime= ff,
            };
            await _widgetInstanceService.AddAsync(win);


        }
        public async Task SaveLayout(ContainerStructureWidgets cw, string userName, string userRoleName)
        {
            List<Guid> widgetIds = null;

            if (cw.Widgets != null)
            {
                widgetIds = cw.Widgets.Select(uu => new Guid(uu.WidgetInstanceID)).ToList();

            }
            //درصورتی که ذخیره بخواد بکنه بعد از لود حالت پیش فرض یوزر جی یو آی دی امپتی هستش
            List<WidgetInstance> winss = await _dashboardUnitOfWork.WidgetInstances.GetUserContainerStructureWidgetInstanceListAsync(userName, cw.ContainerStructureUniqID);
            foreach (WidgetInstance ins in winss)
            {
                if (widgetIds == null || widgetIds.IndexOf(ins.ID) == -1)
                {
                    await _widgetInstanceService.RemoveByIdAsync(ins.ID);
                }
            }
            if (cw.Widgets != null)
            {
                foreach (WidgetInfo wi in cw.Widgets)
                {
                    WidgetInstance win = winss.FirstOrDefault(uu => uu.ID == new Guid(wi.WidgetInstanceID));
                    win.ContainerStructureID = cw.ContainerStructureUniqID;
                    int lastU = wi.ContainerID.LastIndexOf('_');
                    win.ContainerID = wi.ContainerID.Substring(lastU + 1, wi.ContainerID.Length - (lastU + 1));
                    win.Order = wi.Order;
                    win.Visible = true;
                    await _widgetInstanceService.ModifyAsync(win);
                }
            }
        }
        public async Task SaveWidgetInstanceSettings(string userName, Guid widgetInstanceID, string title,  int height)
        {
            WidgetInstance ws= await _widgetInstanceService.RetrieveByIdAsync(widgetInstanceID);
            if (ws.UserName.ToLower() != userName)
            {
                throw new UnauthorizedAccessException("Requsted widget instance is not related to the user");
            }
            ws.Title = title;           
            ws.Height = height + "px";
            ws.LastModificationTime = _dateTimeProviderService.GetNow();
            ws.LastModifiedBy = userName;
            await _widgetInstanceService.ModifyAsync(ws);

        }
        public async Task SaveWidgetInstanceConfig(string userName, Guid widgetInstanceID, string configString)
        {
            WidgetInstance ws = await _widgetInstanceService.RetrieveByIdAsync(widgetInstanceID);
            if (ws.UserName.ToLower() != userName)
            {
                throw new UnauthorizedAccessException("Requsted widget instance is not related to the user");
            }
            ws.Config = configString;
            ws.LastModificationTime = _dateTimeProviderService.GetNow();
            ws.LastModifiedBy = userName;
            await _widgetInstanceService.ModifyAsync(ws);
        }
        public async Task<List<WidgetDto>> GetUserAvailableWidgets(string userRoleName)
        =>
            (await _dashboardUnitOfWork.WidgetAccesses.GetRoleWidgets(userRoleName)).Select(uu=>new WidgetDto(uu)).ToList();
        
    }
}
