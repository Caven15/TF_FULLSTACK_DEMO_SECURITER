using DemoSecurityDal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurityDal.Interfaces
{
    public interface IUserRepository
    {
        // Login
        UserData LoginUser(string email, string password); 

        // Register
        void RegisterUser(UserData data);
    }
}
