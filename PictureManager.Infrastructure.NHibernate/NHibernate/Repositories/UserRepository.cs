using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Repositories.NHibernate;
using NHibernate;
using NHibernate.Linq;
using Abp.Application.Services;

namespace PictureManager
{
    public class UserRepository : NhRepositoryBase<User, int>, IUserRepository
    {
        public List<User> GetAllUsers()
        {
            var query = GetAll();
            query = query.Where(user => user.Id > 0);

            return query
                .ToList();
        }

        public User GetUser(string Login, string Password)
        {
            var query = GetAll();
            query = query.Where(user => user.Login == Login && user.Password == Password);            
            var result = query.ToList();
            var resultUser = new User();
            
            if (result.Count > 0)
            {
                resultUser = result[0];
            }
            
            return resultUser;          
        }

        public int GetUserId(string Login)
        {
            var query = GetAll();
            query = query.Where(user => user.Login == Login);
            var result = query.ToList();
            var resultId = 0;

            if (result.Count > 0)
            {
                resultId = result[0].Id;
            }

            return resultId;
        }
    }
}
