﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace PictureManager
{
    public class UserDto : EntityDto<long>
    {
        public string Login { get; set;} 
        public string Password { get; set; }
    }
}
