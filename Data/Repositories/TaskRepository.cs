using Delloite.TaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delloite.TaskManager.Data.Contracts.Respositories;
using System.Linq.Expressions;
using Delloite.TaskManager.Data.Contexts;

namespace Delloite.TaskManager.Data.Repositories
{
    public sealed class TaskRepository : ITaskRepository
    {
        private DbTaskManagerContext _DbContext;

        public TaskRepository()
        {
            this._DbContext = new DbTaskManagerContext();
        }

        public void Add(TaskEntity entity_)
        {
            try
            {
                this._DbContext.TaskEntites.Add(entity_);
                this._DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TaskEntity> Find(Expression<Func<TaskEntity, bool>> filter_)
        {
            return this._DbContext.TaskEntites.Include("User")
                        .Where(filter_).ToList();
        }
   
        public TaskEntity Get(int id_)
        {
            return this._DbContext.TaskEntites.Include("User").FirstOrDefault(task => task.Id == id_);
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return this._DbContext.TaskEntites
                                    .Include("User")
                                    .Where(x=> !x.Status.Equals("Delete"))
                                    .OrderByDescending(x=> x.CreationDate)
                                    .ToList();
        }

        public void Remove(int id_)
        {
            try
            {
                var taskRemove = this._DbContext.TaskEntites.Where(x => x.Id == id_).FirstOrDefault();
                taskRemove.LastModifiedDate = DateTime.Now;
                taskRemove.Status = "Delete";
                this._DbContext.Entry(taskRemove).State = System.Data.Entity.EntityState.Modified;
                this._DbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(TaskEntity entity_)
        {
            try
            {
                entity_.LastModifiedDate = DateTime.Now;
                this._DbContext.Entry(entity_).State = System.Data.Entity.EntityState.Modified;
                this._DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
