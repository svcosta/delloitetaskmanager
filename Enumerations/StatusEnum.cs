using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delloite.TaskManager.Enumerations
{
    public enum StatusEnum
    {
        [Description("Open")]
        Open,
        [Description("In Progress")]
        InProgress,
        [Description("For Validation")]
        ForValidation,
        [Description("On Hold")]
        OnHold,
        [Description("Closed")]
        Closed
    }
}
