using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Mapping;

namespace PictureManager
{
    public class CommentMap : EntityMap<Comment, int>
    {
        public CommentMap()
            : base("Comments")
        {
            Map(x => x.Text);
            References(x => x.AssignedPicture).Column("PictureId").LazyLoad();
            References(x => x.AssignedUser).Column("UserId").LazyLoad();
        }
    }
}
