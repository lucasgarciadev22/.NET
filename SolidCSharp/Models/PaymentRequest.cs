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

        public PaymentRequest(PaymentType paymentType, double value)
        {
            this.Value = value;
        }
    }
}