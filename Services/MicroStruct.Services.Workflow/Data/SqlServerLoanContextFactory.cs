using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroStruct.Services.WorkflowApi.Data
{
    public class SqlServerLoanContextFactory : IDesignTimeDbContextFactory<LoanContext>
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public SqlServerLoanContextFactory(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
        }
        public SqlServerLoanContextFactory()
        {
            _env = null;
        }
        private string getElsaConnectionString()
        {
            
            if (_env == null)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.development.json", false).Build();
                var elsaSection = config.GetSection("Elsa");
                return elsaSection.GetConnectionString("SqlServer");
            }
            else
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings" +(String.IsNullOrWhiteSpace(_env.EnvironmentName) ? "" : _env.EnvironmentName) + ".json", false).Build();

                var elsaSection = config.GetSection("Elsa");
                return elsaSection.GetConnectionString("SqlServer");
            }
          
        }
        public LoanContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LoanContext>();
            var connectionString = getElsaConnectionString();

            Console.WriteLine("Used connectionString:"+connectionString);
            Console.WriteLine("Args Count:"+args.Count().ToString()+" :");
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
            builder.UseSqlServer(connectionString, db => db.MigrationsAssembly(typeof(SqlServerLoanContextFactory).Assembly.GetName().Name));



            return new LoanContext(builder.Options);
        }
    }
}
