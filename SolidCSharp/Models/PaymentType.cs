using System.Runtime.Serialization;

namespace SolidCSharp.Models
{
  public enum PaymentType
    {
        [EnumMember(Value = "Debit")]
        DEBIT,
        [EnumMember(Value = "Credit")]
        CREDIT
    }
}