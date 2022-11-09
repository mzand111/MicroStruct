using MicroStruct.Web.HttpServices.Dashboard.Dto;
using MZBase.Microservices.HttpServices;

namespace MicroStruct.Web.HttpServices.Dashboard
{
    public interface IDashboardHttpService : IMicroServiceProxy
    {
        Task AddWidgetInstanceToMyContainer(string containerStructureUniqID, string containerID, Guid widgetID);
        Task<List<WidgetInstanceDto>> GetDefaultContainerStructureWidgetInstanceList(string containerStructureID);
        Task<List<WidgetDto>> GetMyAvailableWidgets();
        Task<List<WidgetInstanceDto>> GetMyContainerStructureWidgetInstanceList(string containerStructureID);
        Task SaveLayout(ContainerStructureWidgets cw);
        Task SaveWidgetInstanceConfig(Guid widgetInstanceID, string configString);
        Task SaveWidgetInstanceSettings( Guid widgetInstanceID, string title, int height);
    }
}
