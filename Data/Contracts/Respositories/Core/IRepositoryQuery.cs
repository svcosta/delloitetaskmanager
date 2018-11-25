using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Contracts.Respositories.Core
{
    public interface IRepositoryQuery<TEntity> where TEntity : Delloite.TaskManager.Data.Entities.Core.Entity<Int32>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(Int32 id_);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, Boolean>> filter_);
    }
}


