using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace PictureManager
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        List<Comment> GetAllComments(int? pictureId, int? userId);
    }
}
