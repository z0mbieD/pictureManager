using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace PictureManager
{
    public class AddCommentInput : IInputDto
    {
        public int? UserId { get; set; }
        public int? PictureId { get; set; }
        public string Text { get; set; }
    }
}
