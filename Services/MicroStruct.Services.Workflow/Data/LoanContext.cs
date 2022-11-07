using MicroStruct.Services.WorkflowApi.Models;
using Microsoft.EntityFrameworkCore;


namespace MicroStruct.Services.WorkflowApi.Data
{
    public class LoanContext : DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {
            //Console.WriteLine("0");
        }
        //public LoanContext() : base(GetOptions())
        //{
        //    Console.WriteLine("1");
        //}
        private static string getConnectionString()
        {
            var environmentName =
              Environment.GetEnvironmentVariable(
                  "ASPNETCORE_ENVIRONMENT");

            //Console.WriteLine("2");
            var config = new ConfigurationBuilder().AddJsonFile("appsettings" + (String.IsNullOrWhiteSpace(environmentName) ? "" : "."+environmentName) + ".json", false).Build();
          
            var elsaSection = config.GetSection("Elsa");
            return elsaSection.GetConnectionString("SqlServer");
        }
        //private static DbContextOptions GetOptions()
        //{
        //    //Console.WriteLine("3");
        //    var options = new DbContextOptionsBuilder();
        //    options.UseSqlServer(getConnectionString());
        //    return options.Options;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Console.WriteLine("4");
            optionsBuilder.UseSqlServer(getConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoanRequestPermission>().HasKey(t => new { t.StateActionID, t.LoanRequestLocalID,t.RoleLocalID });


        }

        public DbSet<RoleLocal> RoleLocals { get; set; } = default!;
        
        public DbSet<LoanRequestPermission> LoanRequestPermissions { get; set; } = default!;
        public DbSet<StateAction> StateActions { get; set; } = default!;


        public DbSet<LoanRequestLocal> LoanRequestLocals { get; set; } = default!;
        public DbSet<DepartmentLocal> DepartmentLocals { get; set; } = default!;

    }
}
