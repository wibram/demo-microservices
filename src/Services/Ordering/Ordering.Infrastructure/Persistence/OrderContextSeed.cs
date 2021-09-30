using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync( OrderContext orderContext, ILogger<OrderContextSeed> logger )
        {
            if ( !orderContext.Orders.Any() )
            {
                orderContext.Orders.AddRange( GetPreconfiguredOrders() );

                await orderContext.SaveChangesAsync();

                logger.LogInformation(
                    "Seeding database associated with context {DbContextName} finished.",
                    typeof( OrderContext ).Name );
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order {
                    UserName = "ibo",
                    FirstName = "Ibo",
                    LastName = "Obi",
                    EmailAddress = "ibo@ibo.com",
                    AddressLine = "Burg",
                    Country = "Germanidis",
                    TotalPrice = 750
                }
            };
        }
    }
}
