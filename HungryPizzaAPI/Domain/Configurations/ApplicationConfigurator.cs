using HungryPizzaAPI.Domain.Interfaces;
using HungryPizzaAPI.Domain.Repositories;
using HungryPizzaAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HungryPizzaAPI.Domain.Configurations
{
    public class ApplicationConfigurator
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _serviceCollection;

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
            _serviceCollection.AddScoped<IOrderService,OrderService>();
            _serviceCollection.AddScoped<OrderRepository>();
            _serviceCollection.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("ConnectionString"))
            );
        }
    }
}