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
    public class Picture : Entity<int>
    {
        [ForeignKey("Id")]
        public virtual string PictureName { get; set; }
        public virtual string Tags { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime DateAdded { get; set; }
        public virtual byte[] PictureFile { get; set; }
        public virtual string PictureMimeType { get; set; }

        public Picture()
        {
            DateAdded = DateTime.Now;
        }
    }
}