using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Entities
{
    public partial class TaskEntity : Delloite.TaskManager.Data.Entities.Core.Entity<Int32>
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

        public virtual UserEntity User { get;  set; }
        public virtual UserEntity Owner { get; set; }
        public virtual UserEntity UserUpdate { get; set; }
    }
}