using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureManager.Web.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string PictureName { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PictureFile { get; set; }
    }
}