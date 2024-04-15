using DemoSecurityDal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurityBll.Interfaces
{
    public interface IUserService
    {
        // Login
        UserModel LoginUser(string email, string password);

        // Register
        void RegisterUser(UserModel data);
    }
}
