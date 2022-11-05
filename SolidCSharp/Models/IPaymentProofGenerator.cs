using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
    public interface IPaymentProofGenerator
    {
        public PaymentProof Generate(PaymentRequest paymentRequest);
    }
}