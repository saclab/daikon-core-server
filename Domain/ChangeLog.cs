using System;

namespace Domain
{
  public class ChangeLog
  {
    public Guid Id { get; set; }
    public string EntityName { get; set; }
    public string PropertyName { get; set; }
    public string Type { get; set; }
    public string PrimaryKeyValue { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime DateChanged { get; set; }
  }
}