using MicroStruct.Services.Dashboard.Domain.Model;
using MZBase.Infrastructure;

namespace MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IWidgetInstanceRepository : ILDRCompatibleRepositoryAsync<WidgetInstance, Guid>
    {
        Task<List<WidgetInstance>> GetUserContainerStructureWidgetInstanceListAsync(string userName, string containerStructureID);
    }
}
