using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace MicroStruct.Services.WorkflowApi.Providers
{
    public static class ElsaApiAuthorization
    {
        public static IApplicationBuilder UseElsaApiAuthorization(this IApplicationBuilder app, string policyName)
        {
            return app.UseWhen(IsElsaApiRequest, x => x.Use(ApplyPolicy));

            bool IsElsaApiRequest(HttpContext ctx)
            {
                var endpoint = ctx.Features.Get<IEndpointFeature>()?.Endpoint;
                var descriptor = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();
                var controllerAssembly = descriptor?.ControllerTypeInfo.Assembly;

                return controllerAssembly == typeof(Elsa.Server.Api.ElsaApiOptions).Assembly;
            }

            async Task ApplyPolicy(HttpContext ctx, Func<Task> next)
            {
                var authorizationService = ctx.RequestServices.GetRequiredService<IAuthorizationService>();
                var authorizationResult = await authorizationService.AuthorizeAsync(ctx.User, policyName);

                if (authorizationResult.Succeeded)
                {
                    await next();
                }
                else
                {
                    ctx.Response.StatusCode = 403;
                }
            }
        }
        public static IApplicationBuilder UseElsaApiAuthorizationForAdmin(this IApplicationBuilder app)
        {
            return app.UseWhen(IsElsaApiRequest, x => x.Use(ApplyPolicy));

            bool IsElsaApiRequest(HttpContext ctx)
            {
                var endpoint = ctx.Features.Get<IEndpointFeature>()?.Endpoint;
                var descriptor = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();
                var controllerAssembly = descriptor?.ControllerTypeInfo.Assembly;

                return controllerAssembly == typeof(Elsa.Server.Api.ElsaApiOptions).Assembly;
            }

            async Task ApplyPolicy(HttpContext ctx, Func<Task> next)
            {
                var authorizationService = ctx.RequestServices.GetRequiredService<IAuthorizationService>();
                RolesAuthorizationRequirement rolesAuthorizationRequirement = new RolesAuthorizationRequirement( new List<string> { "Admin" });
                var authorizationResult = await authorizationService.AuthorizeAsync(ctx.User,null,new List<IAuthorizationRequirement>() { rolesAuthorizationRequirement });

                if (authorizationResult.Succeeded)
                {
                    await next();
                }
                else
                {
                    ctx.Response.StatusCode = 403;
                }
            }
        }
    }
}
