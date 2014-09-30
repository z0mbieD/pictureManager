using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace PictureManager
{
    internal static class DtoMappings
    {
        public static void Map()
        {
            Mapper.CreateMap<Picture, PictureDto>();
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<Comment, CommentDto>();
        }
    }
}
