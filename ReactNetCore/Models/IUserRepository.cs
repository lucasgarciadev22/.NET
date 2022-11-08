using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.Models
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();

        UserModel Add(UserModel user);
    }
}