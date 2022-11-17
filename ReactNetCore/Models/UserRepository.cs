using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetCore.Models
{
    public class UserRepository : IUserRepository
    {
        private List<UserModel> users = new List<UserModel>();
        private int _nextId = 1;
        public UserRepository()
        {
            Add(new UserModel { firstName = "Lucas", lastName = "Garcia", email = "lucasgarciadev22@gmail.com" });
        }

        //implementing interface :
        public IEnumerable<UserModel> GetAll()
        {
            return users;
        }

        public UserModel Add(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User can't be null");
            }
            user.Id = _nextId++;
            users.Add(user);
            return user;
        }

        public void Remove(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User can't be null");
            }
            users.RemoveAt(user.Id);
        }
    }
}