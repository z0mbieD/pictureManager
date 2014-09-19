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
    public class User : Entity<int>
    {
        [ForeignKey("Id")]
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
    }
}