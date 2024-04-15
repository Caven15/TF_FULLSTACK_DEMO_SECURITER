using DemoSecurityDal.Data;
using DemoSecurityDal.Interfaces;
using DemoSecurityDal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DemoSecurityDal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Connection _connection;

        public UserRepository(Connection connection)
        {
            _connection = connection;
        }
        public UserData LoginUser(string email, string password)
        {
            Command command = new Command("SPUserLogin", true);

            command.AddParameter("Email", email);
            command.AddParameter("Password", password);

            return _connection.ExecuteReader(command, er => er.DbToDal()).SingleOrDefault();
        }

        public void RegisterUser(UserData data)
        {
            Command command = new Command("SPUserRegister", true);

            command.AddParameter("Nom", data.Nom);
            command.AddParameter("Email", data.Email);
            command.AddParameter("DateNaissance", data.DateNaissance);
            command.AddParameter("Password", data.Password);

            _connection.ExecuteNonQuery(command);
        }
    }
}
