using DemoSecurityDal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurityBll.Mapper
{
    public static class MApper
    {
        internal static UserData BllToDal(this UserModel model)
        {
            return new UserData()
            {
                Nom = model.Nom,
                Email = model.Email,
                DateNaissance = model.DateNaissance,
                Password = model.Password
            };
        }

        internal static UserModel DalToBll(this UserData data)
        {
            if (data == null) { return null; }

            return new UserModel()
            {
                Id = data.Id,
                Nom = data.Nom,
                Email = data.Email,
                DateNaissance = data.DateNaissance,
                Password = data.Password,
                RoleId = data.RoleId
            };
        }
    }
}