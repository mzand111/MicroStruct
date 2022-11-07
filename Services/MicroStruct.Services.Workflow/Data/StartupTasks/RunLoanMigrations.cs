using Elsa.Persistence.EntityFramework.Core;
using Elsa.Services;
using Microsoft.EntityFrameworkCore;

namespace MicroStruct.Services.WorkflowApi.Data.StartupTasks
{
    public class RunLoanMigrations : IStartupTask
    {
        private readonly IDbContextFactory<LoanContext> _dbContextFactory;

        public RunLoanMigrations(IDbContextFactory<LoanContext> dbContextFactoryFactory)
        {
            _dbContextFactory = dbContextFactoryFactory;
        }

        public int Order => 0;

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            await dbContext.Database.MigrateAsync(cancellationToken);
            await dbContext.DisposeAsync();
        }
    }
}
