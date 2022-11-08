using MicroStruct.Services.Dashboard.Data;
using MicroStruct.Services.Dashboard.Domain.Model;
using MicroStruct.Services.Dashboard.Infrastructure.Repository;
using MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces;
using MZBase.Domain;
using MZBase.EntityFrameworkCore;
using MZBase.Infrastructure;

namespace MicroStruct.Services.Dashboard.Infrastructure.UnitOfWork
{
    public class DashboardUnitOfWork : UnitOfWorkAsync<DashboardDbContext>, IDashboardUnitOfWork
    {
        public DashboardUnitOfWork() : base(new DashboardDbContext())
        {
            Widgets = new WidgetRepository(_dbContext);
            WidgetAccesses = new WidgetAccessRepository(_dbContext);
            WidgetInstances= new WidgetInstanceRepository(_dbContext);
        }
        public IWidgetRepository Widgets { get; private set; }
        public IWidgetAccessRepository WidgetAccesses { get; private set; }
        public IWidgetInstanceRepository WidgetInstances { get; private set; }

        public ILDRCompatibleRepositoryAsync<T, PrimKey> GetRepo<T, PrimKey>()
          where T : Model<PrimKey>
          where PrimKey : struct
        {
            ILDRCompatibleRepositoryAsync<T, PrimKey> ff = null;

            if (typeof(T) == typeof(Widget))
            {
                ff = Widgets as ILDRCompatibleRepositoryAsync<T, PrimKey>;

            }
            else if (typeof(T) == typeof(WidgetAccess))
            {
                ff = WidgetAccesses as ILDRCompatibleRepositoryAsync<T, PrimKey>;
            }
            else if (typeof(T) == typeof(WidgetInstance))
            {
                ff = WidgetInstances as ILDRCompatibleRepositoryAsync<T, PrimKey>;
            }


            return ff;
        }

    }
}
