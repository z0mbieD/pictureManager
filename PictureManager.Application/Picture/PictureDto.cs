using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace PictureManager
{
    public class PictureDto : EntityDto<long>
    {
        public string PictureName { get; set;} 
        public string Tags { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PictureFile { get; set; }
        public string PictureMimeType { get; set; }

    }
}
