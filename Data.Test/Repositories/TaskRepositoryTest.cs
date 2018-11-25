using Delloite.TaskManager.Data.Contracts.Respositories;
using Delloite.TaskManager.Data.Entities;
using Delloite.TaskManager.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Test.Repositories
{
    [TestClass]
    public class TaskRepositoryTest
    {
        IUserRepository _repUser;
        ITaskRepository _repTask;

        [TestInitialize]
        public void SetUp()
        {
            _repUser = new UserRepository();
            _repTask = new TaskRepository();
        }

        [TestMethod]
        public void TestingRepositoryAddNewTask()
        {
            try
            {
                // scenario 1: get user
                var user = this._repUser.Get("test2", "pwd123");

                var date = DateTime.Now;

                // scenario 1: create new task
                var newTask = new TaskEntity
                {
                    Title = "Task has created by test",
                    Description = "test ",
                    UserId = user.Id,
                    CreationDate = date,
                    LastModifiedDate = date,
                    Status = "Open",
                    OwnerId = user.Id,
                    UserUpdateId = user.Id,
                    Priority = "Low"
                };          


                // executing the action
                this._repTask.Add(newTask);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }


        [TestMethod]
        public void TestingRepositoryUpdateTask()
        {
            try
            {
                // scenario 1: get user  
                var task = this._repTask.Get(1);
                task.Status = "InProgress";
                task.Description = "Updated by Test Repository";
                task.UserUpdateId = task.UserId; // the same user who has created the task.
                

                // executing the action
                this._repTask.Update(task);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }


        [TestMethod]
        public void TestingRepositoryGetAllTask()
        {
            try
            {
                // scenario 1: get user  
                var list = this._repTask.GetAll();

                Assert.IsTrue(list.Count() > 1, "The Task was not greater than One");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }


        [TestMethod]
        public void TestingRepositoryFilterTasksWithStatusEqualsOpen()
        {
            try
            {
                // scenario 1: get user  
                var list = this._repTask.Find(x => x.Status.Equals("Open"));

                Assert.IsTrue(list.Count() > 1, "The Task was not greater than One");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }


        [TestMethod]
        public void TestingRepositoryDeleteTask()
        {
            try
            {
                this._repTask.Remove(2);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }
    }
}
