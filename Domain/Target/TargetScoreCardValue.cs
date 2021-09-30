using System;

namespace Domain
{
  public class TargetScoreCardValue
  {
    public Guid Id { get; set; }
    public Guid TargetScorecardId { get; set; }
    public string TargetAccessionNumber { get; set; }
    public Question Question { get; set; }
    public Guid QuestionId { get; set; }
    public string QuestionIdentification { get; set; }
    public string QuestionModule { get; set; }
    public string QuestionSubModule { get; set; }
    public string Answer { get; set; }
    public string Description { get; set; }
    public string AnswerdBy { get; set; }
  }
}