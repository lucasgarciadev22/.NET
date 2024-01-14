namespace PizzaManagerRescaffolding.Models;

public partial class Customer
{
    public string FirstAndLastNames => $"{FirstName} {LastName}";
}
