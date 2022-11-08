using MicroStruct.Services.Dashboard.Data;
using MicroStruct.Services.Dashboard.Data.Entities;
using MicroStruct.Services.Dashboard.Domain.Model;
using MicroStruct.Services.Dashboard.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroStruct.Services.Dashboard.Infrastructure.Repository
{
    public class WidgetInstanceRepository : MZBase.EntityFrameworkCore.LDRCompatibleRepositoryAsync<WidgetInstanceEntity, WidgetInstance, Guid>, IWidgetInstanceRepository
    {
        private readonly DashboardDbContext _dbContext;

        public WidgetInstanceRepository(DashboardDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<WidgetInstance>> GetUserContainerStructureWidgetInstanceListAsync(string userName, string containerStructureID)
        => await _dbContext.WidgetInstances.Where(uu => uu.UserName.ToLower() == userName.ToLower() && containerStructureID.ToLower() == containerStructureID.ToLower()).Cast<WidgetInstance>().ToListAsync();
        
    }
}
