using System;

namespace Domain
{
  public class GenePromotionQuestionaireAnswer
  {
    public Guid Id { get; set; }
    public Gene Gene { get; set; }
    public Guid GeneID { get; set; }
    public string GeneAccessionNumber { get; set; }
    public string Status { get; set; }
    public Domain.Question.Question Question { get; set; }
    public Guid QuestionId { get; set; }
    public string QuestionIdentification { get; set; }
    public string QuestionModule { get; set; }
    public string Answer { get; set; }
    public string Description { get; set; }
    public string AnswerdBy { get; set; }

  }
}