using Delloite.TaskManager.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Services.Contracts
{
    public interface IUserService
    {
        UserSessionDTO GetUser(String userName, String passowrd);        
    }
}
