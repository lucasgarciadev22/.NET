﻿namespace PizzaManager.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}