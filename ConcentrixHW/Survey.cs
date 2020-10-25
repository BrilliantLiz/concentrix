using System;

namespace ConcentrixHW
{
    public class DemoSurvey
    {
        public Survey[] Demo { get; set; }
    }

    public class Survey
    {
        public int RespondentId { get; set; }
        public int? ShiftedRespNo { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? WhenChanged { get; set; }
        public decimal? Weight1 { get; set; }
        public int? AnswerCount { get; set; }
        public AnswerParent[] Answers { get; set; }
        
    }

    public class AnswerParent 
    {
        public string QLabel { get; set; }
        public string ResponseText { get; set; }
        public string KeyWord { get; set; }
        public int? Punch { get; set; }
        public string StringValue { get; set; }
        public string Comment { get; set; }
        public decimal? NumericValue { get; set; }
        public AnswerChild[] Answers { get; set; }
        public string AudioPath { get; set; }
    }

    public class AnswerChild
    {
        public string ResponseText { get; set; }
        public string KeyWord { get; set; }
        public string OtherSpecify { get; set; }
        public string Punch { get; set; }
    }
}


