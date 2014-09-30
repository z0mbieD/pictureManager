using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using System.Web;
using System.Web.Security;

namespace PictureManager
{
    public interface IUserAppService : IApplicationService
    {
        GetUsersOutput GetUsers();
        void AddUser(AddUserInput input);
        User Logon(AddUserInput input);
        void LogOff();
        String GetCurrentUser();
        int GetUserByName(AddUserInput input);
    }
}
