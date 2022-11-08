using MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces;
using MZBase.Infrastructure;

namespace MicroStruct.Services.Dashboard.Infrastructure.UnitOfWork
{
    public interface IDashboardUnitOfWork: IDynamicTestableUnitOfWorkAsync
    {
        IWidgetRepository Widgets { get; }
        IWidgetInstanceRepository WidgetInstances { get; }
        IWidgetAccessRepository WidgetAccesses { get; }
    }
}
