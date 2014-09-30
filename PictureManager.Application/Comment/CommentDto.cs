using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace PictureManager
{
    public class CommentDto : EntityDto<long>
    {
        public int UserId { get; set; }
        public User AssignedUser { get; set; }
        public int PictureId { get; set; }
        public Picture AssignedPicture { get; set; }
        public string Text { get; set;} 
    }
}
