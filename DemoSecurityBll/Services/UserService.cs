using DemoSecurityBll.Interfaces;
using DemoSecurityBll.Mapper;
using DemoSecurityDal.Data;
using DemoSecurityDal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurityBll.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public UserModel LoginUser(string email, string password)
        {
            return _UserRepository.LoginUser(email, password)?.DalToBll();
        }

        public void RegisterUser(UserModel model)
        {
            _UserRepository.RegisterUser(model.BllToDal());
        }
    }
}
