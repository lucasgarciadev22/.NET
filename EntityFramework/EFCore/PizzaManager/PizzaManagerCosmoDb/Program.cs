using Microsoft.Azure.Cosmos.Linq;
using PizzaManagerCosmoDb.Data;
using PizzaManagerCosmoDb.Models;

using PizzaManagerContext context = new();

if (context.Products.IsNull())
{
    Product[] pizzas =
    [
        new() { Name = "Cheese Pizza", Price = 10.99M },
        new() { Name = "Special Meat Pizza", Price = 20.99M },
    ];

    context.AddRange(pizzas);
    context.SaveChanges();
}
else
{
    PrintPizzasOverTenBucks();

    if (GetPizza("special meat pizza") is Product specialMeatPizza)
    {
        specialMeatPizza.Price = 9.99M;

        context.SaveChanges();
    }

    PrintPizzasOverTenBucks();
}

#region AUXILIARY METHODS
void PrintPizzasOverTenBucks()
{
    var pizzasOverTenBucks = context.Products
                                .Where(p => p.Price > 10M)
                                .OrderBy(p => p.Name);

    foreach (Product pizza in pizzasOverTenBucks)
    {
        Console.WriteLine($"Id: {pizza.Id}");
        Console.WriteLine($"Name: {pizza.Name}");
        Console.WriteLine($"Price: ${pizza.Price}");
        Console.WriteLine();
    }
}

Product? GetPizza(string name)
{
    return context.Products
         .FirstOrDefault(p => p.Name.ToLower().Equals(name));
}
#endregion