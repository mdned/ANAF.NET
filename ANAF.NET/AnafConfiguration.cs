using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using RestEase.HttpClientFactory;

namespace ANAF.API
{
    public static class AnafConfiguration
    {
        private const string ANAF_URL = "https://webservicesp.anaf.ro/PlatitorTvaRest/api/v6/ws/tva";

        public static IAnafService GetAnafService() => new AnafService(RestClient.For<IAnafApi>(ANAF_URL));

        public static IServiceCollection AddAnafService(this IServiceCollection services)
        {
            services
                .AddTransient<IAnafService, AnafService>()
                .AddRestEaseClient<IAnafApi>(ANAF_URL, client =>
                {
                    client.JsonSerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                });
            return services;
        }
    }
}