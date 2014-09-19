using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;

namespace PictureManager
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository)
        {
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
            }
            
        } 
    }
}
