using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SolidCSharp.Models
{
    [DataContract]
    public class UserLogin
    {
        public static string GetUserLogin()
        {
            return "lucas.g22@gmail.com";
        }
    }
}