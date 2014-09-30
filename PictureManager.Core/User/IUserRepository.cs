﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace PictureManager
{
    public interface IUserRepository : IRepository<User, int>
    {
        List<User> GetAllUsers();
        User GetUser(string Login, string Password);
        int GetUserId(string Login);
    }
}
