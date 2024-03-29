﻿using System;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace ServerSelectionCommittee
{
    class SendEmail
    {
        public string GetPass()
        {
            using (StreamReader streamReader = new StreamReader(@"D:\pass.txt"))
            {
                return streamReader.ReadLine();
            }
        }

        public void Send(EnrolleeSend enrolleeSend)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("program.test@bk.ru", "Приёмная комиссия ПолесГУ");
                // кому отправляем
                MailAddress to = new MailAddress(enrolleeSend.EnrolleeEmail);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Приёмная комиссия ПолесГУ";
                // текст письма
                m.Body = $"Уважаемый(ая) {enrolleeSend.EnrolleeLastname} {enrolleeSend.EnrolleeFirstname[0]}. {enrolleeSend.EnrolleePatronymic[0]}. вы зарегестрировались в приёмной комиссии ПолесГУ";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("program.test@bk.ru", GetPass());
                smtp.EnableSsl = true;
                smtp.Send(m);

                Console.WriteLine($"{DateTime.Now.ToString()}: Отправленно сообщение на почту о регистарии абитуриента  {enrolleeSend.EnrolleeLastname} {enrolleeSend.EnrolleeFirstname[0]}. {enrolleeSend.EnrolleePatronymic[0]}.");

            }
            catch (Exception)
            { }
        }
    }
}