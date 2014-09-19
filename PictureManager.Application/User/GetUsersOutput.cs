using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace PictureManager
{
    public class GetUsersOutput : IOutputDto
    {
        public List<UserDto> Users { get; set; }
    }
}
