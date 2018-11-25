using Delloite.TaskManager.Data.Contexts;
using Delloite.TaskManager.Data.Contracts.Respositories;
using Delloite.TaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Repositories
{
    public sealed class UserRepository : IUserRepository
    {

        private DbTaskManagerContext _DbContext;

        public UserRepository()
        {
            this._DbContext = new DbTaskManagerContext();
        }

        public void Add(UserEntity user_)
        {
            try
            {
                this._DbContext.UserEntites.Add(user_);
                this._DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }     

        public IEnumerable<object> GetAll()
        {
            return this._DbContext.UserEntites
                                   .Select(x=> new {
                                        Id = x.Id,
                                        UserName = x.UserName
                                   })
                        .ToList();
        }

        public UserEntity Get(string userName, string password)
        {
            return this._DbContext.UserEntites.FirstOrDefault(user => user.UserName.Equals(userName) && user.Password.Equals(password));
        }
        
    }
}
