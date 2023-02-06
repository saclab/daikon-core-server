using System;
using Domain;

namespace Application.Targets.DTOs
{
  public class TargetPromotionDataDTO
  {

    public Guid TargetId { get; set; }
    public Guid QuestionId { get; set; }
    public string Answer { get; set; }
    public string Description { get; set; }

  }
}