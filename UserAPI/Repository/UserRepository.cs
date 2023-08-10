using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
           if(_context.Users.Where(u => user.Email == u.Email).ToList().Count > 0)
           {
                throw new Exception("User already exists");
           }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public User Edit(User user)
        {
           User selectedUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (selectedUser != null)
            {
                return selectedUser;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        public User Get(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
