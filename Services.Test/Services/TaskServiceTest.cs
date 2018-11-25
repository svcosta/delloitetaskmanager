using Delloite.TaskManager.Data.Contracts.Respositories;
using Delloite.TaskManager.Data.Repositories;
using Delloite.TaskManager.DataTransferObject;
using Delloite.TaskManager.Services;
using Delloite.TaskManager.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Test.Services
{
    [TestClass]
    public sealed class TaskServiceTest
    {
        ITaskService _taskService;

        [TestInitialize]
        public void SetUp()
        {
         
            //Create Task repository
            ITaskRepository rep = new TaskRepository();

            //SOLID  = Indepence Injection
            this._taskService = new TaskService(rep);
        }

        [TestMethod]
        public void TestingTaskServiceGetAllList()
        {
            try
            {
                // scenario 1: get user
                var list = this._taskService.GetAllTasks();
                Assert.IsTrue(list.Count() > 1, "The Task List was not greater than One");

                var status = this._taskService.GetStatusList();

                var prioritry = this._taskService.GetPriorityList();

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }

        [TestMethod]
        public void TestingTaskServiceAddNewTask()
        {
            try
            {
                var date = DateTime.Now;
                var userId = 1;
                // scenario 1: create new task
                var newTask = new TaskDTO
                {
                    Title = "Task has created by Service test",
                    Description = "Service Test",
                    UserId = userId,
                    CreationDate = date,
                    LastModifiedDate = date,
                    Status = "Open",
                    OwnerId = userId,
                    UserUpdateId = userId,
                    Priority = "Low"
                };


                // executing the action
                this._taskService.Create(newTask);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }


        [TestMethod]
        public void TestingTaskServiceUpdateTask()
        {
            try
            {
                var taskId = 2;
                // scenario 1: get user  
                var task = this._taskService.GetTask(taskId);
                task.Status = "Closed";
                task.Description = "Updated Service Task";
                task.Priority = "None";
                task.UserUpdateId = task.UserId; // the same user who has created the task.


                // executing the action
                this._taskService.Update(task);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }



        [TestMethod]
        public void TestingTaskServiceDelete()
        {
            try
            {
                var taskId = 3;
                this._taskService.Remove(taskId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }
    }
}
