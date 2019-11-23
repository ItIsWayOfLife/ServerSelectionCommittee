﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (DataContext db = new DataContext())
            //{
            //    foreach (Enrollee en in db.Enrollees)
            //    {
            //        Console.WriteLine($"id: {en.IdEnrollee} льгота: {en.Concession} email: {en.EnrolleeEmail}  ");
            //    }
            //}


            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("End");


            // запись в xml

            Console.WriteLine("Start");


            BudgetOrChargeSend.DataSerializable();
            ConcessionSend.DataSerializable();

             ContractEnSend.DataSerializable();
            DepartmentSend.DataSerializable();
            DocumentsSend.DataSerializable();
            EnrolleeSend.DataSerializable();
            FacultySend.DataSerializable();
            FormStudySend.DataSerializable();
            HistorySend.DataSerializable();
            LevelEducationSend.DataSerializable();
            RelativeOrGuardianSend.DataSerializable();
            SpecialtySend.DataSerializable();
            TrainingDirectionSend.DataSerializable();
            TrainingPeriodSend.DataSerializable();
            UserSend.DataSerializable();

            Console.WriteLine("End");

            Console.ReadKey();
        }
    }
}
