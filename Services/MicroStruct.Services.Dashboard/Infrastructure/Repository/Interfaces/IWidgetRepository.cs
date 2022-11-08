using MicroStruct.Services.Dashboard.Domain.Model;
using MZBase.Infrastructure;

namespace MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IWidgetRepository : ILDRCompatibleRepositoryAsync<Widget, Guid>
    {
    }
}
