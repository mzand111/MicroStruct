using MicroStruct.Web.Config;
using MicroStruct.Web.HttpServices.Dashboard.Dto;
using Microsoft.Extensions.Options;
using MZBase.Microservices.HttpServices;
using System.Collections.Generic;
using System.ComponentModel;

namespace MicroStruct.Web.HttpServices.Dashboard
{
    public class DashboardHttpService : ServiceMediatorBase<DashboardHttpService>, IDashboardHttpService
    {

        public DashboardHttpService(HttpClient httpClient, ILogger<DashboardHttpService> logger, IOptions<ServiceUrls> serviceUrls) : base(httpClient, logger, serviceUrls.Value.DashboardAPI, "Dashboard")
        {

        }

        public async Task AddWidgetInstanceToMyContainer(string containerStructureUniqID, string containerID, Guid widgetID)
        => await PostAsync("/Dashboard/AddWidgetInstanceToMyContainer?containerStructureUniqID=" + containerStructureUniqID + "&containerID=" + containerID + "&widgetID=" + widgetID);

        public async Task<List<WidgetInstanceDto>> GetDefaultContainerStructureWidgetInstanceList(string containerStructureID)
       => await GetAsync<List<WidgetInstanceDto>>("/Dashboard/GetDefaultContainerStructureWidgetInstanceList?containerStructureID=" + containerStructureID);

        public async Task<List<WidgetDto>> GetMyAvailableWidgets()
        => await GetAsync<List<WidgetDto>>("/Dashboard/GetMyAvailableWidgets");

        public async Task<List<WidgetInstanceDto>> GetMyContainerStructureWidgetInstanceList(string containerStructureID)
       => await GetAsync<List<WidgetInstanceDto>>("/Dashboard/GetMyContainerStructureWidgetInstanceList?containerStructureID=" + containerStructureID);

        public async Task SaveLayout(ContainerStructureWidgets cw)
        => await PostAsync(cw, "/Dashboard/SaveLayout");

        public async Task SaveWidgetInstanceConfig(Guid widgetInstanceID, string configString)
         => await PostAsync("/Dashboard/SaveWidgetInstanceConfig?widgetInstanceID=" + widgetInstanceID + "&configString=" + configString );

        public async Task SaveWidgetInstanceSettings(Guid widgetInstanceID, string title, int height)
        => await PostAsync("/Dashboard/SaveWidgetInstanceSettings?widgetInstanceID=" + widgetInstanceID + "&title=" + title + "&height=" + height);
    }
}
