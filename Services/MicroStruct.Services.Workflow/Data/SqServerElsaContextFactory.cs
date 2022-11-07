using Elsa.Persistence.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroStruct.Services.WorkflowApi.Data
{
    public class SqServerElsaContextFactory : IDesignTimeDbContextFactory<ElsaContext>
    {
        public ElsaContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddCommandLine(args)
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder();
            var connectionString = configuration.GetConnectionString("SqlServer");
          
            if (string.IsNullOrEmpty(connectionString))
            {
                if (args.Any())
                {
                    connectionString = args.Last();
                }
            }
            Console.WriteLine(connectionString);
            dbContextBuilder.UseSqlServer(connectionString, options => options.MigrationsAssembly(typeof(Elsa.Persistence.EntityFramework.SqlServer.SqlServerElsaContextFactory).Assembly.FullName));

            return new ElsaContext(dbContextBuilder.Options);
        }
    }
}
