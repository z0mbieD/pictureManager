using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace PictureManager
{
    public interface IUserAppService : IApplicationService
    {
        GetUsersOutput GetUsers();
        void AddUser(AddUserInput input);
    }
}
