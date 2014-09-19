using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;

namespace PictureManager
{
    public class PictureAppService : ApplicationService, IPictureAppService
    {
        private readonly IPictureRepository _pictureRepository;
        public PictureAppService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public GetPicturesOutput GetPictures()
        {
            var pictures = _pictureRepository.GetAllPictures();
            //Pictures = Mapper.Map<List<PictureDto>>(pictures)

            return new GetPicturesOutput
            {
                Pictures = Mapper.Map<List<PictureDto>>(pictures)
            }; 
        }

        public void AddPicture(AddPictureInput input)
        {
            if (input != null)
            {
                var picture = new Picture
                {
                    PictureName = input.PictureName,
                    Tags = input.Tags,
                    Description = input.Description,
                    DateAdded = DateTime.Now,
                    PictureFile = new byte[input.PictureFile.Length],
                  //  PictureMimeType = input.PictureMimeType
                };
               
                _pictureRepository.Insert(picture);
            }
            
        } 
    }
}
