using System;
using Domain.Core;

namespace Domain
{
  public class Reply : Metadata
  {
    public Guid Id { get; set; }
    public Guid DiscussionId { get; set; }
    public string Body { get; set; }
    public string PostedBy { get; set; }
    public DateTime Timestamp { get; set; }
    public string[] Mentions { get; set; }
    public string[] Tags { get; set; }

  }
}