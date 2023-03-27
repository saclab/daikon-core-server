using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core
{
  public class Metadata
  {
    public DateTime LastEditAt { get; set; }
    public string LastEditBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsArchived { get; set; }
    public bool IsPublished { get; set; }
    public bool IsDraft { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsPublic { get; set; }
    public bool IsReadOnly { get; set; }
    public bool IsLocked { get; set; }
    public bool IsHidden { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsDisabled { get; set; }
    public bool IsApproved { get; set; }
    public bool IsRejected { get; set; }
    public bool IsPending { get; set; }
    public bool IsExpired { get; set; }
  }
}