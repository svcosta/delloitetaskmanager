using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Entities
{
    public partial class UserEntity: Delloite.TaskManager.Data.Entities.Core.Entity<Int32>
    {
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Role { get; set; }
        public String Password { get; set; }
        public Boolean IsActive { get; set; }

        public virtual ICollection<TaskEntity> Tasks { get; set; }
    }
}
