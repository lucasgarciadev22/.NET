using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
namespace SolidCSharp.Models
{
  public class PaymentProof
    {
        public string Description { get; set; }
        public string User { get; set; }
        public string Value { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType PaymentType { get; set; }

        public PaymentProof(string description, string value, PaymentType paymentType)
        {
            Description = description;
            Value = value;
            PaymentType = paymentType;
        }
    }
}