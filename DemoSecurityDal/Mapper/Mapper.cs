using DemoSecurityDal.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurityDal.Mapper
{
    public static class Mapper
    {
        internal static UserData DbToDal(this IDataRecord record)
        {
            return new UserData()
            {
                Id = (int)record["Id"],
                Nom = (string)record["Nom"],
                Email = (string)record["Email"],
                DateNaissance = (DateTime)record["DateNaissance"]
            };
        }
    }
}
