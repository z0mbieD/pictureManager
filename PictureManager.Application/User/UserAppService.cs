using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;

namespace PictureManager
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        public IPrincipal User;
        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository)
        {
            FormsAuthentication.Initialize();
            _userRepository = userRepository;
        }

        public GetUsersOutput GetUsers()
        {
            var users = _userRepository.GetAllUsers();

            return new GetUsersOutput
            {
                Users = Mapper.Map<List<UserDto>>(users)
            }; 
        }

        public int GetUserByName(AddUserInput input)
        {
            var userId = _userRepository.GetUserId(input.Login);

            return userId;
        }

        public void AddUser(AddUserInput input)
        {
            if (input != null)
            {
                var user = new User
                {
                    Login = input.Login,
                    Password = input.Password,
                };
                

                _userRepository.Insert(user);
                Logon(input);
                
               /* return new GetUsersInput
                {
                    User = Mapper.Map<UserDto>(user)
                }; */
            }
            
        }

        public User Logon(AddUserInput input)
        {
            if (input != null)
            {
                var curentUser = _userRepository.GetUser(input.Login, input.Password);
                if (curentUser.Id != 0)
                {
                    FormsAuthentication.SetAuthCookie(curentUser.Login, true);
                    return curentUser;
                }
            }

            return null;
        }

        public String GetCurrentUser()
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    string username = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    return username;
                }
            }

            return "";           
        }

        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}
