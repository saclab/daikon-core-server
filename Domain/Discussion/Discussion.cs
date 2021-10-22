using System;
using System.Collections.Generic;

namespace Domain
{
  public class Discussion
  {
    public Guid Id { get; set; }
    public string Reference { get; set; }
    public string Section { get; set; }
    public string Topic { get; set; }
    public string Description { get; set; }
    public string PostedBy { get; set; }
    public DateTime Timestamp { get; set; }
    public string[] Mentions { get; set; }
    public string[] Tags { get; set; }
    public List<Reply> Replies { get; set; }

  }
}