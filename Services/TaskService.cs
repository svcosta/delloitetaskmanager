using Delloite.TaskManager.Data.Contracts.Respositories;
using Delloite.TaskManager.Data.Entities;
using Delloite.TaskManager.Data.Repositories;
using Delloite.TaskManager.DataTransferObject;
using Delloite.TaskManager.Enumerations;
using Delloite.TaskManager.Services.Contracts;
using Delloite.TaskManager.Services.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Services
{
    public sealed class TaskService : ITaskService
    {
        ITaskRepository _repTask;      

        public TaskService(ITaskRepository repTask)
        {
            _repTask = repTask;
        }
        public void Create(TaskDTO dto)
        {
            ValidateTask(dto,true);
            try
            {
                var date = DateTime.Now;
                var newTask =  new TaskEntity
                {                   
                    UserId = dto.UserId,
                    OwnerId = dto.UserId,
                    UserUpdateId = dto.UserId,
                    Title = dto.Title,
                    Description = dto.Description,
                    Priority = dto.Priority,
                    Status = dto.Status,
                    CreationDate = date,
                    LastModifiedDate = date
                };

                this._repTask.Add(newTask);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TaskDTO GetTask(int id)
        {
            return this._repTask.Get(id).ToDto();
        }

        public IEnumerable<object> GetAllTasks()
        {
            return this._repTask.GetAll();
        }

        public IEnumerable<object> GetAllByUser(int ownerId)
        {
            var tasks = this._repTask.Find(x => x.OwnerId == ownerId && !x.Status.Equals("Delete"))
                                     .OrderByDescending(t=> t.LastModifiedDate);

            return tasks.Select(x => new
            {
                Id = x.Id,
                UserId = x.UserId,
                OwnerId = x.OwnerId,
                Title = x.Title,
                Owner = x.Owner.UserName,
                Priority = x.Priority,
                Status = x.Status,
                Date = x.LastModifiedDate.ToString("dd/MM/yyyy hh:mm")
            }).ToList();
        }

        public IEnumerable<PriorityEnum> GetPriorityList()
        {
            return Enum.GetValues(typeof(PriorityEnum)).Cast<PriorityEnum>();
        }

        public IEnumerable<StatusEnum> GetStatusList()
        {
            return Enum.GetValues(typeof(StatusEnum)).Cast<StatusEnum>();
        }

        public void Remove(int id)
        {
            this._repTask.Remove(id);
        }

        public void Update(TaskDTO dto)
        {
            ValidateTask(dto);
            try
            {
                var taskEntity = _repTask.Get(dto.Id);

                taskEntity.OwnerId = dto.OwnerId;
                taskEntity.UserUpdateId = dto.UserUpdateId;              
                taskEntity.Description = dto.Description;
                taskEntity.Priority = dto.Priority;
                taskEntity.Status = dto.Status;

                this._repTask.Update(taskEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateTask(TaskDTO task, Boolean isCreation=false)
        {
            if (task.UserId == 0 && isCreation)
                throw new ApplicationException("The User must be informed");

            if (String.IsNullOrEmpty(task.Title) && isCreation)
                throw new ApplicationException("The Title field must be informed");

            if (String.IsNullOrEmpty(task.Description))
                throw new ApplicationException("The Description field must be informed");

            if (String.IsNullOrEmpty(task.Status))
                throw new ApplicationException("The Status field must be informed");

            if (String.IsNullOrEmpty(task.Priority))
                throw new ApplicationException("The Priority field must be informed");
        }

    }
}
