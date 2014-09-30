using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace PictureManager
{
    public class GetCommentsInput : IInputDto
    {
        public int? PictureId { get; set; }
        public int? UserId { get; set; }
    }
}
