using HomeBookkeepingApp.Data;
using HomeBookkeepingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HomeBookkeepingApp
{
    public static class SeedHB
    {
        public static void SeedDatabase(HomeBookkeepingAppContext context)
        {
            context.Database.Migrate();
            if (context.Consumptions.Count() == 0 && context.Categories.Count() == 0)
            {
                Category c1 = new Category { CategoryName = "Food"};
                Category c2 = new Category { CategoryName = "Transport" };
                Category c3 = new Category { CategoryName = "Mobile connection" };
                Category c4 = new Category { CategoryName = "Internet" };
                Category c5 = new Category { CategoryName = "Enterteinment" };

                context.Consumptions.AddRange(
                    new Consumption
                    {
                        DateConsumption = DateTime.Parse("2022, 1, 22"),                     
                        Category = c1,
                        Sum = 1200M,
                        Comment = "Food apple"
                    },
                     new Consumption
                     {
                         DateConsumption = DateTime.Parse("2022,2,22"),
                         Category = c2,
                         Sum = 500M,
                         Comment = "Transport car"
                     },
                     new Consumption
                     {
                         DateConsumption = DateTime.Parse("2022, 2, 20"),
                         Category = c3,
                         Sum = 100M,
                         Comment = "Mobile connection MTS"
                     },
                     new Consumption
                     {
                         DateConsumption = DateTime.Parse("2022, 4, 19"),
                         Category = c4,
                         Sum = 400M,
                         
                     },
                     new Consumption
                     {
                         DateConsumption = DateTime.Parse("2022, 1, 20"),
                         Category = c5,
                         Sum = 200M,
                         Comment = "Enterteinment jump"
                     }
                     );
                context.SaveChanges();
            }
        }
    }
}
