using HungryPizzaAPI.Domain.Configurations;
using HungryPizzaAPI.Domain.Models.Tables;

namespace HungryPizzaAPITest.Configuration
{
    public class DatabaseSeeder
    {
        public static void Seed(DatabaseContext databaseContext)
        {
            databaseContext.Tastes.Add(new Tastes {Id = 1, Name = "3 Queijos", Price = 50f});
            databaseContext.Tastes.Add(new Tastes {Id = 2, Name = "Frango com requeijão", Price = 59.99f});
            databaseContext.Tastes.Add(new Tastes {Id = 3, Name = "Mussarela", Price = 42.50f});
            databaseContext.Tastes.Add(new Tastes {Id = 4, Name = "Calabresa", Price = 42.50f});
            databaseContext.Tastes.Add(new Tastes {Id = 5, Name = "Pepperoni", Price = 55f});
            databaseContext.Tastes.Add(new Tastes {Id = 6, Name = "Portuguesa", Price = 45f});
            databaseContext.Tastes.Add(new Tastes {Id = 7, Name = "Veggie", Price = 59.99f});
        }
    }
}