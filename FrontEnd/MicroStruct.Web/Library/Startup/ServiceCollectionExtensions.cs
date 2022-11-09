using MicroStruct.Web.HttpServices;
using MicroStruct.Web.HttpServices.Dashboard;

using MZBase.Microservices.HttpServices;

namespace MicroStruct.Web.Library.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services, bool bypassCertificateValidation, int handlerLifeTimeMinuts)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();


            #region Dashboard
            registerHttpService<IDashboardHttpService, DashboardHttpService>(services, bypassCertificateValidation, handlerLifeTimeMinuts);
            #endregion Dashboard

            return services;
        }
        private static IHttpClientBuilder registerHttpService<TInterface, TImplementation>(IServiceCollection services,
            bool bypassCertificateValidation = false
            , int handlerLifeTimeMinuts = 5)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            var f = services.AddHttpClient<TInterface, TImplementation>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(handlerLifeTimeMinuts))
                 .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>(); 
            if (bypassCertificateValidation)
            {
                f.ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

                });
            }
            return f;
        }

    }
}
