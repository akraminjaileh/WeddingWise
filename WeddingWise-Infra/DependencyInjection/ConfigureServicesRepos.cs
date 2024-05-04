using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Infra.Repos;
using WeddingWise_Infra.Services;

namespace WeddingWise.ServicesReposConfig
{
    public static class ConfigureServicesRepos
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepos, AdminRepos>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IGetRepos, GetRepos>();
            services.AddScoped<IGetServices, GetServices>();
            services.AddScoped<IAccountRepos, AccountRepos>();
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IClientRepos, ClientRepos>();
            
        }


    }
}
