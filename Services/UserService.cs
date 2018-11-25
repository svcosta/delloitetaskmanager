using Delloite.TaskManager.Data.Contracts.Respositories;
using Delloite.TaskManager.Data.Repositories;
using Delloite.TaskManager.DataTransferObject;
using Delloite.TaskManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repUser;


        public UserService()
        {
            this._repUser = new UserRepository();
        }

        public UserService(IUserRepository repUser)
        {
            _repUser = repUser;
        }        

        public UserSessionDTO GetUser(string userName, string passowrd)
        {
            var _token = String.Empty;

            var user = this._repUser.Get(userName, passowrd);

            if (user == null)
            {
                throw new ApplicationException("User not found. Check your login or password are correct.");
            }

            _token = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(String.Format("{0}:{1}", user.UserName, user.Password)));

            var userSesion = new UserSessionDTO { id = user.Id, userName= user.UserName, token = _token };

            return userSesion;
        }
    }
}
