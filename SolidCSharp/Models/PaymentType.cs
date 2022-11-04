using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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