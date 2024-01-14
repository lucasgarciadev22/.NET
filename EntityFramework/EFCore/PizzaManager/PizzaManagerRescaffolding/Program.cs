using Microsoft.IdentityModel.Tokens;
using PizzaManagerRescaffolding.Data;
using PizzaManagerRescaffolding.Models;

using PizzaManagerContext context = new();
if (context.Customers.IsNullOrEmpty())
{
    Customer[] customers =
    [
        new() { FirstName = "Juan", LastName = "Hernandez" },
        new() { FirstName = "Lucas", LastName = "Garcia" },
    ];

    context.AddRange(customers);
    context.SaveChanges();
}

foreach (Customer customer in context.Customers)
    Console.WriteLine($"Full name: {customer.FirstAndLastNames}");
