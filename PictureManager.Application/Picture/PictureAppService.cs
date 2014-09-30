using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;

namespace PictureManager
{
    public class PictureAppService : ApplicationService, IPictureAppService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IUserRepository _userRepository;
        
        public PictureAppService(IPictureRepository pictureRepository, IUserRepository userRepository)
        {
            _pictureRepository = pictureRepository;
            _userRepository = userRepository;
        }

        public GetPicturesOutput GetPictures(GetPicturesInput input)
        {
            var pictures = _pictureRepository.GetAllPictures(input.UserId);

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
                    PictureMimeType = input.PictureMimeType,
                    PictureData = input.PictureData
                };

                if (input.UserId.HasValue)
                {
                    var user = new User { 
                        Id = input.UserId.Value
                    };

                    picture.AssignedUser = user;
                }
               
                _pictureRepository.Insert(picture);
            }
        } 
    }
}
