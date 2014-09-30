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
    public class PictureRepository : NhRepositoryBase<Picture, int>, IPictureRepository
    {
        public List<Picture> GetAllPictures(int? userId)
        {
            var query = GetAll();

            if (userId.HasValue)
            {
                query = query.Where(picture => picture.AssignedUser.Id == userId.Value);
            }

            return query
                .Fetch(picture => picture.AssignedUser)
                .ToList();
        }
    }
}
