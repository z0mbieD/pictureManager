using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace PictureManager
{
    public interface IPictureRepository : IRepository<Picture, int>
    {
        List<Picture> GetAllPictures();
    }
}
