using AutoMapper;
using HungryPizzaAPI.Domain.Requests;
using HungryPizzaAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HungryPizzaAPI.Domain.Configurations
{
    public class ApplicationConfigurator
    {
        private IServiceCollection _serviceCollection;
        private IConfiguration _configuration;
        public ApplicationConfigurator(IServiceCollection service, IConfiguration configuration)
        {
            _serviceCollection = service;
            _configuration = configuration;
        }

        public void ConfigureServices()
        {
            _serviceCollection.Configure<HungryPizzaMongoSettings>(
                _configuration.GetSection(nameof(HungryPizzaMongoSettings)));
            _serviceCollection.AddSingleton<IHungryPizzaMongoSettings>(setting =>
                setting.GetRequiredService<IOptions<HungryPizzaMongoSettings>>().Value);
            _serviceCollection.AddSingleton<OrderService>();
        }
    }
}