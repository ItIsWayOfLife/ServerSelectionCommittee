using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerSelectionCommittee
{
    public class ClientObject
    {
        public TcpClient client;

        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }


        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[256];
                while (true)
                {
                    // Получаем сообщение
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = response.ToString();
                    Console.WriteLine(message);

                    //
                    //

                    // вход 
                    if (message.StartsWith("LoginTo"))
                    {                     
                        data = Encoding.Unicode.GetBytes(LogIn.LogInTo(message));
                        //
                        //
                        // Отправляем сообщение обратно
                       // stream.Write(data, 0, data.Length);

                    }

                    // данные на направл подготовки
                    if (message.StartsWith("GetTD"))
                    {
                        data = Encoding.Unicode.GetBytes(GetTrainingDirectionSend.GetTD());
                        //
                        //
                        // Отправляем сообщение обратно
                      //  stream.Write(data, 0, data.Length);

                    }

                    // данные абитуриентов
                    if (message.StartsWith("GetEnrollee"))
                    {
                        data = Encoding.Unicode.GetBytes(GetEnrollee.GetData());
                        //
                        //
                        // Отправляем сообщение обратно
                        //  stream.Write(data, 0, data.Length);

                    }

                    if (message.StartsWith("GetLevelEducation"))
                    {
                        data = Encoding.Unicode.GetBytes(GetLevelEducationSend.GetData());
                    }


                    if (message.StartsWith("GetConcessionSend"))
                    {
                        data = Encoding.Unicode.GetBytes(GetConcessionSend.GetData());
                    }


                    if (message.StartsWith("AddEnrollee"))
                    {
                        data = Encoding.Unicode.GetBytes(AddEnrollee.AddData(message));
                    }

                    if (message.StartsWith("DeleteEnrollee "))
                    {
                        data = Encoding.Unicode.GetBytes(DeleteEnrollee.DeleteEn(message));
                    }

                    stream.Write(data, 0, data.Length);
                }
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
