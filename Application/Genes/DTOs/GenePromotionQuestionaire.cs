using System;
using System.Collections.Generic;

namespace Application.Genes.DTOs
{
    public class Answer {
        public string AnswerValue { get; set; }
        public string AnswerDescription { get; set; }
    }
    public class GenePromotionQuestionaire
    {
        public Guid GeneID { get; set; }
        public Dictionary<string, Answer> Answers { get; set; }
    }
}