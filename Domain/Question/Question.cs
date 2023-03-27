using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core;

namespace Domain
{
  public class Question : Metadata
  {

    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string Module { get; set; }
    public string SubModule { get; set; }
    public string QuestionBody { get; set; }
    public string Notes { get; set; }
    public string ToolTip { get; set; }
    public string[] PossibleAnswers { get; set; }

  }
}