
namespace Delloite.TaskManager.Data.Migrations
{
    using Delloite.TaskManager.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Delloite.TaskManager.Data.Contexts.DbTaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Delloite.TaskManager.Data.Contexts.DbTaskManagerContext context)
        {
            // here you can enter data via migrations. Every time update-database is given the method see is executed.

            List<TaskEntity> tasks = new List<TaskEntity>();

            for (int i = 0; i < 10; i++)
            {
                var date = DateTime.Now;

                tasks.Add(new TaskEntity
                {
                    Id = i + 1,
                    Title = "Task " + i,
                    Description = "To do " + i,
                    UserId = 1,
                    OwnerId = 1,
                    UserUpdateId = 1,
                    CreationDate = date,
                    LastModifiedDate = date,
                    Status = "Open",
                    Priority = "High"
                });
            }


            var user = new UserEntity
            {
                Id = 1,
                UserName = "test",
                Email = "test@delloite.com",
                Password = "pwd123",
                IsActive = true,
                Role = "Administrator",
                Tasks = tasks
            };



            var user2 = new UserEntity
            {
                Id = 2,
                UserName = "test2",
                Email = "test2@delloite.com",
                Password = "pwd123",
                IsActive = true,
                Role = "Developer"
            };


            var user3 = new UserEntity
            {
                Id = 3,
                UserName = "test3",
                Email = "test3@delloite.com",
                Password = "pwd123",
                IsActive = true,
                Role = "Project Manager"
            };


            context.UserEntites.Add(user);
            context.UserEntites.Add(user2);
            context.UserEntites.Add(user3);

        }
    }
}
