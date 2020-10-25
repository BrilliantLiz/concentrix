using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ConcentrixHW
{
    class DemoSurveyHw
    {
        static void Main()
        {
            try
            {
                Survey[] jsonData = (JsonConvert.DeserializeObject<Survey[]>
                    (File.ReadAllText(@"../../../DemoSurveys_v1.1.json")));

                // Total number of surveys
                Console.WriteLine("Total number of surveys is  " + jsonData.Length);

                // Trend number of surveys by month
                string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                Survey[] Surveys_2020 = Array.FindAll(jsonData, jd => jd.CompleteDate.Value.Year == 2020);
                Console.WriteLine("Monthly trends in 2020: ");
                for (int i = 01; i <= 12; i++)
                {
                    int count = Surveys_2020.Count(s => s.CompleteDate.Value.Month == i);
                    Console.WriteLine(monthNames[i - 1] + " - " + count);
                }

                //Promoters surveys
                int promotersSurveysNumber = 0;
                foreach (Survey surv in jsonData)
                {
                    AnswerParent[] promotersSurveys = Array.FindAll(surv.Answers, sa => sa.QLabel == "DQNPS" && sa.ResponseText == "Promoter" &&
                         surv.AnswerCount == 72);
                    promotersSurveysNumber = promotersSurveys.Length != 0 ? promotersSurveysNumber + 1 : promotersSurveysNumber;
                }
                Console.WriteLine("Number of promoters surveys is " + promotersSurveysNumber);
                Console.WriteLine("Percentage of promoters surveys is " +
                   ((double)promotersSurveysNumber / (double)jsonData.Length).ToString("0.000"));

                //Closed cases
                int closedCasesCount = 0;
                foreach (Survey surv in jsonData)
                {
                    AnswerParent[] closedCases = Array.FindAll(surv.Answers, sa => sa.QLabel == "DQASTAT" && sa.ResponseText == "Closed");
                    closedCasesCount = closedCases.Length != 0 ? closedCasesCount + 1 : closedCasesCount;
                }

                Console.WriteLine("Number of closed cases is " + closedCasesCount);
                Console.WriteLine("Percentage of closed cases is " +
                    ((double)closedCasesCount / (double)jsonData.Length).ToString("0.000%"));

                // Survey 410
                AnswerParent FXDTETME_data = Array.Find(jsonData[409].Answers, sa => sa.QLabel == "FXDTETME");
                AnswerParent FXEMAIL_data = Array.Find(jsonData[409].Answers, sa => sa.QLabel == "FXEMAIL");
                AnswerParent FXOSITE_data = Array.Find(jsonData[409].Answers, sa => sa.QLabel == "FXOSITE");
                AnswerParent QOSR_data = Array.Find(jsonData[409].Answers, sa => sa.QLabel == "QOSR");

                Console.WriteLine("Data for survey #410: ");
                Console.WriteLine("Survey Date: " + Convert.ToDateTime(FXDTETME_data.StringValue).ToString("MM/dd/yyyy"));
                Console.WriteLine("Email Address: " + FXEMAIL_data.StringValue);
                Console.WriteLine("Site: " + FXOSITE_data.StringValue);
                Console.WriteLine("Respondent Comment: " + QOSR_data.Comment);

                Console.WriteLine("End of programm " + DateTime.Now);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
