using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain.AppBackgroundTasks
{
  public class AppBackgroundTaskLog : Metadata
  {
    // Background Task properties that needs to be tracked
    public Guid Id { get; set; }
    public string TaskName { get; set; }
    public string TaskConfigurationKey { get; set; }
    public string TaskDescription { get; set; }
    public string TaskStatus { get; set; }
    public string TaskType { get; set; }
    public string TaskModule { get; set; }
    public string TaskSubModule { get; set; }
    public string TaskResult { get; set; }
    public string TaskResultMessage { get; set; }
    public string TaskResultData { get; set; }

    public DateTime TaskStartTime { get; set; }
    public DateTime TaskEndTime { get; set; }
    public DateTime TaskLastUpdated { get; set; }
    public DateTime TaskCreated { get; set; }

    public string TaskCreatedBy { get; set; }



  }
}