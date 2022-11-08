using MicroStruct.Services.Dashboard.Data;
using MicroStruct.Services.Dashboard.Data.Entities;
using MicroStruct.Services.Dashboard.Domain.Model;
using MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces;

namespace MicroStruct.Services.Dashboard.Infrastructure.Repository
{
    public class WidgetAccessRepository : MZBase.EntityFrameworkCore.LDRCompatibleRepositoryAsync<WidgetAccessEntity, WidgetAccess, WidgetAccessKey>, IWidgetAccessRepository
    {
        private readonly DashboardDbContext _dbContext;

        public WidgetAccessRepository(DashboardDbContext context) : base(context)
        {
            _dbContext = context;
        }
       public async Task<List<Widget>> GetRoleWidgets(string roleName)
            => _dbContext.WidgetAccesses.Where(uu=>uu.RoleName.ToLower()==roleName.ToLower()).Select(uu=>uu.WidgetEntity).Cast<Widget>().ToList();
    }
}
