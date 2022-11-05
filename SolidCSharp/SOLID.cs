using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SolidCSharp.Models;

namespace SolidCSharp
{
  public class LiskovPrincipleExample
  {
    static void Main(string[] args)
    {
      LiskovPayment();
    }
    public static void LiskovPayment()
    {
      Payment newPayment = new Payment(new CreditPaymentProofGenerator());
      PaymentRequest paymentRequest = CreateCreditPayment();
      PaymentProof paymentProof = newPayment.RegisterNewPayment(paymentRequest);

      Console.WriteLine(JsonConvert.SerializeObject(paymentProof, new Newtonsoft.Json.Converters.StringEnumConverter()));

      newPayment = new Payment(new DebitPaymentProofGenerator());
      paymentRequest = CreateDebitPayment();
      paymentProof = newPayment.RegisterNewPayment(paymentRequest);

      Console.WriteLine(JsonConvert.SerializeObject(paymentProof, new Newtonsoft.Json.Converters.StringEnumConverter()));
    }
    public static PaymentRequest CreateCreditPayment()
    {
      return new PaymentRequest(PaymentType.CREDIT, 89.90, 3);
    }

    public static PaymentRequest CreateDebitPayment()
    {
      return new PaymentRequest(PaymentType.DEBIT, 129.90);
    }
  }
}