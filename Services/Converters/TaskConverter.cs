using Delloite.TaskManager.Data.Entities;
using Delloite.TaskManager.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Services.Converters
{
    public static class TaskConverter
    {
        public static TaskEntity ToEntity(this TaskDTO dto)
        {
            return new TaskEntity
            {
                Id = dto.Id,
                UserId = dto.UserId,
                OwnerId = dto.OwnerId,
                UserUpdateId = dto.UserUpdateId,
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                Status = dto.Status,
                CreationDate = dto.CreationDate,
                LastModifiedDate = dto.LastModifiedDate
            };
        }

        public static TaskDTO ToDto(this TaskEntity entity)
        {
            return new TaskDTO
            {
                Id = entity.Id,
                UserId = entity.UserId,
                OwnerId = entity.OwnerId,
                UserUpdateId = entity.UserUpdateId,
                Title = entity.Title,
                Description = entity.Description,
                Priority = entity.Priority,
                Status = entity.Status,
                CreationDate = entity.CreationDate,
                LastModifiedDate = entity.LastModifiedDate,              
                User = entity.User.ToDto()

            };
        }
    }
}
