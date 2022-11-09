using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tech_test_payment_api.Models
{
  public class OrderRegistry
  {
    [Key()]
    public int Id { get; set; }
    public string StatusMessage { get; set; }
    [ForeignKey("Seller")]
    public int SellerId { get; set; }
    public virtual Seller Seller { get; set; } //lazyload
    public string SellerCpf { get; set; }
    public string SellerName { get; set; }
    public string SellerEmail { get; set; }
    public string SellerPhone { get; set; }
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderProducts { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public OrderRegistry(Seller seller, string orderNumber, DateTime orderDate, string orderProducts, OrderStatus orderStatus)
    {
      SellerCpf = seller.Cpf;
      SellerName = seller.Name;
      SellerEmail = seller.Email;
      SellerPhone = seller.Phone;
      OrderNumber = orderNumber;
      OrderDate = orderDate;
      OrderProducts = orderProducts;
      OrderStatus = orderStatus;
    }
    public OrderRegistry(){}
  }
}