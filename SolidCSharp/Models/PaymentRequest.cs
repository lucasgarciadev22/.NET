using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
  public class PaymentRequest
  {
    public double Value { get; set; }

    public PaymentType PaymentType { get; set; }

    public int Installments { get; set; }

    public PaymentRequest(PaymentType paymentType, double value, int installments = 0)
    {
      PaymentType = paymentType;
      Value = value;
      Installments = installments;
    }
  }
}