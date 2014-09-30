using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace PictureManager
{
    public interface IPictureAppService : IApplicationService
    {
        GetPicturesOutput GetPictures(GetPicturesInput input);
        void AddPicture(AddPictureInput input);
    }
}
