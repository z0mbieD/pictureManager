using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace PictureManager
{
    class PictureMap :  ClassMap<Picture>
    {
        Not.LazyLoad();
        Table("Pictures");
        Id(x => x.Id);
        Map(x => x.PictureName);
        Map(x => x.Tags);
        Map(x => x.Description);
        Map(x => x.DateAdded);
        Map(x => x.PictureFile);
    }
}
