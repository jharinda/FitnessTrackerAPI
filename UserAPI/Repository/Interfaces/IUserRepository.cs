using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        public IEnumerable<User> Get();
        public User Get(string email);

        public User Create(User user);
        public void Delete(User user);
        public User Edit(User user);
    }
}
