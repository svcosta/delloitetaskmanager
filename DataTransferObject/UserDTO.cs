using Delloite.TaskManager.DataTransferObject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.DataTransferObject
{
    public sealed class UserDTO: BaseDTO
    {
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Role { get; set; }      
        public Boolean IsActive { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }


    public sealed class UserSessionDTO
    {
        public Int32 id { get; set; }
        public String userName { get; set; }
        public string token { get; set; }
    }
}
