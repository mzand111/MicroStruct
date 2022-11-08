using MicroStruct.Services.Dashboard.Data;
using MicroStruct.Services.Dashboard.Data.Entities;
using MicroStruct.Services.Dashboard.Domain.Model;
using MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces;

namespace MicroStruct.Services.Dashboard.Infrastructure.Repository
{
    public class WidgetRepository : MZBase.EntityFrameworkCore.LDRCompatibleRepositoryAsync<WidgetEntity, Widget, Guid>, IWidgetRepository
    {
        private readonly DashboardDbContext _dbContext;

        public WidgetRepository(DashboardDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
