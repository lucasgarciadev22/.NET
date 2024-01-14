﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaManager.Models;

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
}
