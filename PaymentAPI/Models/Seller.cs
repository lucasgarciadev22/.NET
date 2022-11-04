using System.ComponentModel.DataAnnotations;

namespace tech_test_payment_api.Models
{
  public class Seller
  {
    [Key()]
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Seller(int id, string cpf, string name, string email, string phone)
    {
      Id = id;
      Cpf = cpf;
      Name = name;
      Email = email;
      Phone = phone;
    }
  }
}