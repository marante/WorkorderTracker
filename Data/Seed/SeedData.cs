using System;
using System.Linq;
using BravisWorkplanner.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BravisWorkplanner.Data.Seed
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BravisDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BravisDbContext>>()))
            {
                // Look for any WorkOrders.
                if (context.WorkOrders.Any())
                {
                    return;   // DB has been seeded
                }

                context.WorkOrders.AddRange(
                    new WorkOrder
                    {
                        Name = "B123",
                        Address = "Testvägen 2",
                        Description = "Vi ska bygga hus",
                        Start = "Fakturerat",
                        Status = "Pågående",
                        SentInvoice = "2017-05-23"
                    },

                    new WorkOrder
                    {
                        Name = "B123",
                        Address = "Testvägen 2",
                        Description = "Vi ska bygga hus",
                        Start = "Fakturerat",
                        Status = "Pågående",
                        SentInvoice = "2017-05-23"
                    },

                    new WorkOrder
                    {
                        Name = "B123",
                        Address = "Testvägen 2",
                        Description = "Vi ska bygga hus",
                        Start = "Fakturerat",
                        Status = "Pågående",
                        SentInvoice = "2017-05-23"
                    },

                    new WorkOrder
                    {
                        Name = "B123",
                        Address = "Testvägen 2",
                        Description = "Vi ska bygga hus",
                        Start = "Fakturerat",
                        Status = "Pågående",
                        SentInvoice = "2017-05-23"
                    },

                    new WorkOrder
                    {
                        Name = "B123",
                        Address = "Testvägen 2",
                        Description = "Vi ska bygga hus",
                        Start = "Fakturerat",
                        Status = "Pågående",
                        SentInvoice = "2017-05-23"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}