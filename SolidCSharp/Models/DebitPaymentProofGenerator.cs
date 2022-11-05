using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
  public class DebitPaymentProofGenerator : IPaymentProofGenerator
  {
    public PaymentProof Generate(PaymentRequest paymentRequest)
    {
      PaymentProof paymentProof = new PaymentProof("Payment complete!", paymentRequest.Value.ToString(), paymentRequest.PaymentType);

      paymentProof.User = UserLogin.GetUserLogin();

      Message.Save(paymentProof);
      
      return paymentProof;
    }
  }
}