using Delloite.TaskManager.Data.Entities;
using Delloite.TaskManager.Data.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Data.Contexts
{
    public sealed class DbTaskManagerContext : DbContext
    {
        #region " Constructor   "

        static DbTaskManagerContext()
        {
            Database.SetInitializer<DbTaskManagerContext>(null);
        }

        public DbTaskManagerContext()
            : base("DelloiteConnectionString")
        {
            //Disable LazyLoad
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //#todo: remove this code later.
            Database.Log = messge => Debug.WriteLine(messge);
        }

        #endregion

        #region " Methods       "

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TaskMap());           

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region " Entities      "

        public DbSet<UserEntity> UserEntites { get; set; }
        public DbSet<TaskEntity> TaskEntites { get; set; }

        #endregion
    }
}
