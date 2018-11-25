using Delloite.TaskManager.DataTransferObject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.DataTransferObject
{
    public class TaskDTO: BaseDTO
    {
        public Int32 UserId { get; set; }
        public Int32 OwnerId { get; set; }
        public Int32 UserUpdateId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Priority { get; set; }
        public String Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public UserDTO User { get; set; }
        public UserDTO Owner { get; set; }
        public UserDTO UserUpdate { get; set; }
    }
}
