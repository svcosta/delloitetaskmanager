using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Contracts.Respositories.Core
{
    public interface IRepository<TEntity> where TEntity : Delloite.TaskManager.Data.Entities.Core.Entity<Int32>
    {
        void Add(TEntity entity_);
        void Update(TEntity entity_);
        void Remove(Int32 id_);
    }
}


