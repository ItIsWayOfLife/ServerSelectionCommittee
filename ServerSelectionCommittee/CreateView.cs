using System.Collections.Generic;
using System.Linq;

namespace ServerSelectionCommittee
{
    class CreateView
    {
        public static string GetView()
        {
            string responseStr = "<html><head><meta charset='utf8'></head><body>";

            responseStr+=  "<title>Мониторинг вступительной компании ПолесГУ</title> <style> td{ width: 130px; height:60px; border: solid 1px silver; text-align:center; } </style>";

            responseStr += "<h1><center>Мониторинг вступительной компании ПолесГУ</center></h1>";

            responseStr += "<table>";

            responseStr += "<tr><td>Специальность</td><td> Бюджет / Платно </td><td> Форма </td><td> Срок обучения </td><td>менее 150 </td><td> 150 - 200 </td><td> 200 - 250 </td><td> 250 - 300</td><td> 300 - 350</td><td> 350 - 400</td></tr>";

            using (DataContext db = new DataContext())
            {
                List<TrainingDirection> trainingDirections = db.TrainingDirections.ToList();

                List<EnrolleeSend> enrolleeSends = EnrolleeSend.GetData();

                foreach (TrainingDirection tr in trainingDirections)
                {

                    responseStr += $"<tr><td>{tr.Specialty.FullNameSpecialty}</td>" +
                        $"<td> {tr.BudgetOrCharge.NameBudgetOrCharge} </td>" +
                        $"<td> {tr.FormStudy.NameFormStudy} </td>" +
                        $"<td> {tr.TrainingPeriod.NameTrainingPeriod} </td>" +
                        $"<td> {(enrolleeSends.Where(p=>p.IdDirectionTraining==tr.IdDirectionTraining)).Where(p=>p.SumScore()<150).ToList().Count} </td>" +
                        $"<td>  {(enrolleeSends.Where(p => p.IdDirectionTraining == tr.IdDirectionTraining)).Where(p => p.SumScore() >= 150 &&  p.SumScore()<200).ToList().Count}</td>" +
                        $"<td>  {(enrolleeSends.Where(p => p.IdDirectionTraining == tr.IdDirectionTraining)).Where(p => p.SumScore() >= 200 && p.SumScore() < 250).ToList().Count} </td>" +
                        $"<td>  {(enrolleeSends.Where(p => p.IdDirectionTraining == tr.IdDirectionTraining)).Where(p => p.SumScore() >= 250 && p.SumScore() < 300).ToList().Count}</td>" +
                        $"<td>  {(enrolleeSends.Where(p => p.IdDirectionTraining == tr.IdDirectionTraining)).Where(p => p.SumScore() >= 300 && p.SumScore() < 350).ToList().Count}</td>" +
                        $"<td>  {(enrolleeSends.Where(p => p.IdDirectionTraining == tr.IdDirectionTraining)).Where(p => p.SumScore() >= 350 && p.SumScore() < 400).ToList().Count}</td></tr>";
                }
            }
            
            responseStr += "</table>";

            responseStr += "</body></html>";

            return responseStr;
        }
    }
}
