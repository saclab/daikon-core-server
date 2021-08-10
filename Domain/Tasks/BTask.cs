using System;

namespace Domain.Tasks
{
  public class BTask
  {
    public Guid Id { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime DateCompleted { get; set; }

  }
}