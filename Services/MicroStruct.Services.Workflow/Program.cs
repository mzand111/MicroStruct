using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using Elsa.Runtime;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MicroStruct.Services.WorkflowApi.Config;
using MicroStruct.Services.WorkflowApi.Customization.Activities;
using MicroStruct.Services.WorkflowApi.Data;
using MicroStruct.Services.WorkflowApi.Data.StartupTasks;
using MicroStruct.Services.WorkflowApi.Providers;
using MicroStruct.Services.WorkflowApi.Providers.WorkfowContexts;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
var elsaSection = configuration.GetSection("Elsa");
var connectionString = elsaSection.GetConnectionString("SqlServer");
// Add services to the container.

builder.Services.Configure<FlowConfig>(configuration.GetSection("Flows"));
builder.Services.Configure<ServiceUrls>(configuration.GetSection("ServiceUrls"));

builder.Services.AddControllers();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })

.AddJwtBearer("Bearer", options =>
{
    options.Authority = configuration["ServiceUrls:IdentityAPI"];
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = false,
        RoleClaimType = JwtClaimTypes.Role,
        NameClaimType = JwtClaimTypes.Name,
    };
    if (configuration.GetValue<bool>("ServerCertificateCustomValidationCallback"))
    {
        options.BackchannelHttpHandler =
        new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
    }
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "microstruct");
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microstruct.Services.Workflow", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"Enter 'Bearer' [space] and your token",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
    
         c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In=ParameterLocation.Header
                        },
                        new List<string>()
                    }

                    });
    }
    );
var webUIorigin = configuration.GetSection("AllowedOrigins").GetValue<string>("WebUI");
builder.Services
    .AddDbContextFactory<LoanContext>(options => options.UseSqlServer(
            connectionString,
            sql => sql.MigrationsAssembly(typeof(MicroStruct.Services.WorkflowApi.Models.LoanRequestLocal).Assembly.FullName)))
    .AddCors(cors => cors.AddDefaultPolicy(policy =>
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(webUIorigin)))

    .AddElsa(elsa => elsa
        .UseEntityFrameworkPersistence(ef => ef.UseSqlServer(connectionString, db => db.MigrationsAssembly(typeof(Elsa.Persistence.EntityFramework.SqlServer.SqlServerElsaContextFactory).Assembly.GetName().Name)), true)
        .AddConsoleActivities()
        .AddJavaScriptActivities()
      //  .AddHttpActivities(options => options.BasePath = "/workflows")
        .AddActivity<PermissionAwareUserTask>()
         
        )
     .AddWorkflowContextProvider<LoanWorkflowContextProvider>()
    .AddStartupTask<RunLoanMigrations>()
    .AddElsaApiEndpoints();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<LoanContext>();
    dataContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microstruct.Services.Workflow v1"));
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseElsaApiAuthorizationForAdmin();
app.Run();
