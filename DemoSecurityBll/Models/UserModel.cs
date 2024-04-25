using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSecurityDal.Data
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nom { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public DateTime DateNaissance { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
