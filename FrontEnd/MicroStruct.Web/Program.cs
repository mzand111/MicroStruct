using Microsoft.AspNetCore.Authentication;
using MicroStruct.Web.Config;
using MicroStruct.Web.Library.Middlewares;
using MicroStruct.Web.Services;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


string loggerConnectionString = configuration.GetConnectionString("SeriLogDB");

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>
                   {
                        new SqlColumn("UserName", SqlDbType.VarChar,true,200),
                        new SqlColumn("IP", SqlDbType.VarChar,true,32),
                        new SqlColumn("UserActionID", SqlDbType.Int),
                        new SqlColumn("RemoteAddress", SqlDbType.VarChar,true,500),
                        new SqlColumn("Category", SqlDbType.VarChar,true,200),
                        new SqlColumn("ServiceMethod", SqlDbType.VarChar,true,200)
                   }
}; //through this coulmnsOptions we can dynamically  add custom columns which we want to add in database  



Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithClientIp()
    .Enrich.WithClientAgent()
    .WriteTo.Console()
    //.Enrich.WithExceptionDetails()
    .WriteTo.MSSqlServer(
            connectionString: loggerConnectionString,
            sinkOptions: new MSSqlServerSinkOptions { TableName = "Log", AutoCreateSqlTable = true },
            sinkOptionsSection: null,
            appConfiguration: null,
            restrictedToMinimumLevel: LogEventLevel.Information,
            formatProvider: null,
            columnOptions: columnOptions,
            columnOptionsSection: null,
            logEventFormatter: null
         )
    .CreateLogger()
    ;
Serilog.Debugging.SelfLog.Enable(msg =>
{
    Debug.Print(msg);
    Debugger.Break();
});
builder.Host.UseSerilog(Log.Logger);
builder.Logging.AddSerilog(Log.Logger);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IWorkflowService, WorkflowService>();
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
  .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
  .AddOpenIdConnect("oidc", options =>
  {
      options.Authority = configuration["ServiceUrls:IdentityAPI"];
      options.GetClaimsFromUserInfoEndpoint = true;
      options.ClientId = "microstruct";
      options.ClientSecret = "secret";
      options.ResponseType = "code";
      options.ClaimActions.MapJsonKey("role", "role", "role");
      options.ClaimActions.MapJsonKey("sub", "sub", "sub");
      options.TokenValidationParameters.NameClaimType = "name";
      options.TokenValidationParameters.RoleClaimType = "role";
      options.Scope.Add("microstruct");
      options.SaveTokens = true;

  });
builder.Services.Configure<ServiceUrls>(configuration.GetSection("ServiceUrls"));
builder.Host.UseSerilog();


try
{
    var app = builder.Build();
    app.UseMiddleware<ErrorHandlerMiddleware>();
    

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        //app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    else
    {
        //app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthentication();
    app.Use(async (httpContext, next) =>
    {
        var userName = "-";
        var client = "-";
        if (httpContext != null)
        {
            userName = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name : "anonymous"; //Gets user Name from user Identity  
            client = httpContext.Connection.RemoteIpAddress.ToString() ?? "unknown";
        }
        LogContext.PushProperty("UserName", userName); //Push user in LogContext;  
        LogContext.PushProperty("IP", client); //Push user in LogContext;  


        await next.Invoke();
    }
                );
    app.UseAuthorization();


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Failed to initialize HostBuilder");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}