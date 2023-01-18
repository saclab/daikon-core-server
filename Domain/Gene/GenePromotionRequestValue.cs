using System;

namespace Domain
{
  public class GenePromotionRequestValue
  {
    public Guid Id { get; set; }
    public Guid GenePromotionRequestId { get; set; }
    public Question Question { get; set; }
    public Guid QuestionId { get; set; }
    public string Answer { get; set; }
    public string Description { get; set; }
    public string AnswerdBy { get; set; }

  }
}