using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
    public class PaymentProof
    {
        public string Description { get; set; }
        public string User { get; set; }
        public string Value { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType PaymentType { get; set; }

        public PaymentProof(string descricao, string valor, PaymentType paymentType)
        {
            this.Value = descricao;
            this.Value = valor;
            this.PaymentType = paymentType;
        }


    }
}