using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Mapping;

namespace PictureManager
{
    public class PictureMap : EntityMap<Picture, int>
    {
        public PictureMap()
            : base("Pictures")
        {
            Map(x => x.PictureName);
            Map(x => x.Tags);
            Map(x => x.Description);
            Map(x => x.DateAdded);
            Map(x => x.PictureMimeType);
            Map(x => x.PictureData).Length(1000000);
            References(x => x.AssignedUser).Column("UserId").LazyLoad();
        }
    }
}
