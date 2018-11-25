using Delloite.TaskManager.DataTransferObject;
using Delloite.TaskManager.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Services.Contracts
{
    public interface ITaskService
    {
        void Create(TaskDTO task);
        void Update(TaskDTO task);
        void Remove(Int32 id);
        IEnumerable<object> GetAllTasks();
        IEnumerable<object> GetAllByUser(Int32 ownerId);
        TaskDTO GetTask(Int32 id);
        IEnumerable<StatusEnum> GetStatusList();
        IEnumerable<PriorityEnum> GetPriorityList();
    }
}
