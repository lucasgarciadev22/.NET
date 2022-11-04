using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
    public class Payment
    {
        private PaymentProofGenerator _paymentProofGenerator;

        public Payment(PaymentProofGenerator paymentProofGenerator)
        {
            this._paymentProofGenerator = paymentProofGenerator;
        }
        public PaymentProof RegisterNewPayment(PaymentRequest paymentRequest)
        {
            PaymentProof paymentProof = _paymentProofGenerator.Generate(paymentRequest);

            return paymentProof;
        }
    }
}