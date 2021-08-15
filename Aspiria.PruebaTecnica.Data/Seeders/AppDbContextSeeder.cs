using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspiria.PruebaTecnica.Data.Seeders
{
    public static class AppDbContextSeeder
    {
        public static void Seed(this AppDbContext context)
        {
            if (!context.Products.Any())
            {
                context.AddRange(new List<Product>
                {
                    new Product
                    {
                        Name = "Dron"
                    },
                    new Product
                    {
                        Name = "Nintendo switch",
                        Company = "Nintendo"
                    },
                    new Product
                    {
                        Name = "Scooter"
                    },
                    new Product
                    {
                        Name = "Play station 1",
                        Company = "Sony"
                    },
                    new Product
                    {
                        Name = "Xbox one",
                        Company = "Microsoft"
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
