using DemoSecurityAPI.Dto;
using DemoSecurityDal.Data;

namespace DemoSecurityAPI.Mapper
{
    public static class Mapper
    {
        internal static UserModel ApiToBll(this UserRegisterForm form)
        {
            return new UserModel()
            {
                Nom = form.Nom,
                Email = form.Email,
                DateNaissance = form.DateNaissance,
                Password = form.Password
            };
        }
    }
}
