using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace PictureManager
{
    public class Comment : Entity<int>
    {
        public virtual Picture AssignedPicture { get; set; }
        public virtual int? PictureId { get; set; }
        public virtual string Text { get; set; }
        public virtual User AssignedUser { get; set; }
        public virtual int? UserId { get; set; }
        
    }
}