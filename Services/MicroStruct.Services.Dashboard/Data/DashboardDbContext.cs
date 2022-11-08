using MicroStruct.Services.Dashboard.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroStruct.Services.Dashboard.Data
{
    public class DashboardDbContext : DbContext
    {
        public DashboardDbContext(DbContextOptions<DashboardDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DashboardDbContext() : base()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WidgetAccessEntity>(b =>
            {
                b.HasKey(c => new { c.WidgetID, c.RoleName });
                b.HasOne(c => c.WidgetEntity).WithMany(uu => uu.WidgetAccessEntities).HasForeignKey(uu => uu.WidgetID);
                b.Property(c => c.RoleName).HasMaxLength(300);
            });
            modelBuilder.Entity<WidgetEntity>(b =>
          {
              b.Property(c => c.Name).HasMaxLength(300);
          });
            modelBuilder.Entity<WidgetInstanceEntity>(b =>
            {
                b.Property(c => c.ContainerID).HasMaxLength(300);
                b.Property(c => c.ContainerStructureID).HasMaxLength(300);
                b.Property(c => c.Width).HasMaxLength(100);
                b.Property(c => c.Height).HasMaxLength(100);
                b.Property(c => c.UserName).HasMaxLength(100);
                b.Property(c => c.CreatedBy).HasMaxLength(100);
                b.Property(c => c.LastModifiedBy).HasMaxLength(100);

            });
        }
        private static string getConnectionString()
        {
            var environmentName =
              Environment.GetEnvironmentVariable(
                  "ASPNETCORE_ENVIRONMENT");

            //Console.WriteLine("2");
            var config = new ConfigurationBuilder().AddJsonFile("appsettings" + (String.IsNullOrWhiteSpace(environmentName) ? "" : "." + environmentName) + ".json", false).Build();


            return config.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Console.WriteLine("4");
            optionsBuilder.UseSqlServer(getConnectionString());
        }
        public DbSet<WidgetEntity> Widgets { get; set; }
        public DbSet<WidgetInstanceEntity> WidgetInstances { get; set; }
        public DbSet<WidgetAccessEntity> WidgetAccesses { get; set; }
    }
}
