using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureManager
{
    public interface IPictureRepository
    {
        void Save(Picture picture);
    }
}
