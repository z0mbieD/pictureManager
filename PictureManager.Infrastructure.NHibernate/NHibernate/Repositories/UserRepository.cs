using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Repositories.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace PictureManager
{
    public class UserRepository : NhRepositoryBase<User, int>, IUserRepository
    {
        public List<User> GetAllUsers()
        {
            var query = GetAll();
           // var query = Session.Query<Picture>();

          //  if (Id.HasValue)
           // {
                query = query.Where(user => user.Id > 0);
           // }

            return query
                .ToList();
        }
    }
}
