using System;
using applicationPool.Models;

namespace applicationPool.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Register(User user);
    }

}

