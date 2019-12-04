using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

                    // вход 
                    if (message.StartsWith("LoginTo"))
                    {                     
                        data = Encoding.Unicode.GetBytes(LogIn.LogInTo(message));
                    }

                    // данные на направл подготовки
                    if (message.StartsWith("GetTD"))
                    {
                        data = Encoding.Unicode.GetBytes(GetTrainingDirectionSend.GetTD(message));
                    }

                    // добавить абитуриента
                    if (message.StartsWith("AddEnrollee"))
                    {
                        data = Encoding.Unicode.GetBytes(AddEnrollee.AddData(message));
                    }

                    // данные абитуриентов
                    if (message.StartsWith("GetEnrollee"))
                    {
                        data = Encoding.Unicode.GetBytes(GetEnrollee.GetData(message));
                    }

                    // обновить абитур
                    if (message.StartsWith("UpdateEnrollee"))
                    {
                        data = Encoding.Unicode.GetBytes(UpdateEnrollee.UpdateData(message));
                    }

                    // возвр историю
                    if (message.StartsWith("OutUser"))
                    {
                        data = Encoding.Unicode.GetBytes(StoreUser.OutUser(message));
                    }


                    if (message.StartsWith("GetDoc"))
                    {
                        data = Encoding.Unicode.GetBytes(GetLevelEducationSend.GetData());
                    }

                    if (message.StartsWith("GetStateData"))
                    {
                        data = Encoding.Unicode.GetBytes(StateData.GetData(message));
                    }


                    if (message.StartsWith("GetLevelEducation"))
                    {
                        data = Encoding.Unicode.GetBytes(GetLevelEducationSend.GetData());
                    }


                    if (message.StartsWith("GetConcessionSend"))
                    {
                        data = Encoding.Unicode.GetBytes(GetConcessionSend.GetData());
                    }



                    if (message.StartsWith("DeleteEnrollee "))
                    {
                        data = Encoding.Unicode.GetBytes(DeleteEnrollee.DeleteEn(message));
                    }

                   

                    // возвращает id посл добавл абит
                    if (message.StartsWith("ReturnLastIdEn "))
                    {
                        data = Encoding.Unicode.GetBytes(ReturnLastIdEn.ReturnId());
                    }

                 

                          // добавляет доки
                    if (message.StartsWith("AddDoc "))
                    {
                        data = Encoding.Unicode.GetBytes(AddDoc.AddData(message));
                    }

                    // возвращает докум
                    if (message.StartsWith("GetDoc "))
                    {
                        data = Encoding.Unicode.GetBytes(GetDoc.GetData(message));
                    }

                    // удал док
                    if (message.StartsWith("DeleteDoc "))
                    {
                        data = Encoding.Unicode.GetBytes(DeleteDoc.DeleteByIdDoc(message));
                    }

                    // обнов док
                    if (message.StartsWith("UpdateDoc "))
                    {
                        data = Encoding.Unicode.GetBytes(UpdateDoc.UpdateData(message));
                    }

                    // возвр историю
                    if (message.StartsWith("GetHis "))
                    {
                        data = Encoding.Unicode.GetBytes(GetHistorySend.GetData());
                    }

                   
                    stream.Write(data, 0, data.Length);
                }
                }
            catch (Exception ex)
            {
               //  Console.WriteLine(ex.Message);
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
