using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
  public class CreditPaymentProofGenerator : IPaymentProofGenerator
  {
    public PaymentProof Generate(PaymentRequest paymentRequest)
    {
      PaymentProof paymentProof = new CreditPaymentProof("Payment complete!", paymentRequest.Value.ToString(),
      paymentRequest.PaymentType, paymentRequest.Installments);
      
      paymentProof.User = UserLogin.GetUserLogin();

      Message.Save(paymentProof);

      return paymentProof;
    }
  }
}