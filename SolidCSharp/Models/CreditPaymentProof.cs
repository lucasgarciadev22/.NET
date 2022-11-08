using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
  public class CreditPaymentProof : PaymentProof
  {
    public int Installments { get; set; }
    public CreditPaymentProof(string description, string value, PaymentType paymentType, int installments) : base(description, value, paymentType)
    {
      Installments = installments;
    }

  }
}