using MicroStruct.Services.Dashboard.Domain.Model;
using MZBase.Infrastructure;

namespace MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IWidgetAccessRepository : ILDRCompatibleRepositoryAsync<WidgetAccess, WidgetAccessKey>
    {
        Task<List<Widget>> GetRoleWidgets(string roleName);
    }

   
}
