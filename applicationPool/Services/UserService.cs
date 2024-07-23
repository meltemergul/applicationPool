using System;
using applicationPool.Models;
using System.Collections.Generic;
using System.Linq;
using applicationPool.Data;

namespace applicationPool.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            return user;
        }

        public User Register(User user)
        {
            if (_context.Users.Any(x => x.Username == user.Username))
                return null;

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}

