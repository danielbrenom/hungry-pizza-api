using HungryPizzaAPI;
using HungryPizzaAPI.Domain.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HungryPizzaAPITest.Integration
{
    public class ApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Testing.json").Build();

                services.Configure<HungryPizzaMongoSettings>(
                    configuration.GetSection(nameof(HungryPizzaMongoSettings)));
                services.AddSingleton<IHungryPizzaMongoSettings>(setting =>
                    setting.GetRequiredService<IOptions<HungryPizzaMongoSettings>>().Value);

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<DatabaseContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<ApplicationFactory<TStartup>>>();
                    // Ensure the database is created.
                    appDb.Database.EnsureCreated();
                }
            });
        }
    }
}