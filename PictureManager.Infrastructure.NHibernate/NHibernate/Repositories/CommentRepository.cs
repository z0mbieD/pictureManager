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
    public class CommentRepository : NhRepositoryBase<Comment, int>, ICommentRepository
    {
        public List<Comment> GetAllComments(int? pictureId, int? userId)
        {
            var query = GetAll();

            if (userId.HasValue)
            {
                query = query.Where(comment => comment.AssignedUser.Id == userId.Value);
            } 

            if (pictureId.HasValue)
            {
                query = query.Where(comment => comment.AssignedPicture.Id == pictureId.Value);
            }

            return query
                .Fetch(comment => comment.AssignedPicture)
                .Fetch(comment => comment.AssignedUser)
                .ToList();
        }
    }
}
