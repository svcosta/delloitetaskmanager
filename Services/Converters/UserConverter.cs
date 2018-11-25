using Delloite.TaskManager.Data.Entities;
using Delloite.TaskManager.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Services.Converters
{
    //Class to convert Entity to DTO and vice-versa
    public static class UserConverter
    {
        public static UserEntity ToEntity(this UserDTO dto)
        {
            return new UserEntity
            {
                Id = dto.Id,
                Email = dto.Email,
                UserName = dto.UserName,
                Role = dto.Role,             
                IsActive = dto.IsActive                
               
            };
        }

        public static UserDTO ToDto(this UserEntity entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                Email = entity.Email,
                UserName = entity.UserName,
                Role = entity.Role,              
                IsActive = entity.IsActive

            };
        }
    }
}
