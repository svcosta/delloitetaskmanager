using Delloite.TaskManager.Data.Contracts.Respositories.Core;
using Delloite.TaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Delloite.TaskManager.Data.Contracts.Respositories
{
    public interface IUserRepository 
    {
        void Add(UserEntity user_);
        IEnumerable<object> GetAll();
        UserEntity Get(string userName, string password);
    }
}
