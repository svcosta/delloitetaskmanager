using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Entities.Core
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
