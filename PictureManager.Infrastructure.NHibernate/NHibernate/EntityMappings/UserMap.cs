using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Mapping;

namespace PictureManager
{
    public class UserMap : EntityMap<User, int>
    {
        public UserMap()
            : base("Users")
        {
            Map(x => x.Login);
            Map(x => x.Password);
        }
    }
}
