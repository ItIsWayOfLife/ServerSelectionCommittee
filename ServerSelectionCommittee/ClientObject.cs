using System;
using System.Net.Sockets;
using System.Text;


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
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на вход в систему");
                        data = Encoding.Unicode.GetBytes(LogIn.LogInTo(message)); 
                    }
                    // данные на направл подготовки
                    if (message.StartsWith("GetTD"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на получения направлений подготовки");
                        data = Encoding.Unicode.GetBytes(GetTrainingDirectionSend.GetTD(message)); 
                    }
                    // добавить абитуриента
                    if (message.StartsWith("AddEnrollee"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на добавление абитуриента");
                        data = Encoding.Unicode.GetBytes(AddEnrollee.AddData(message)); 
                    }
                    // данные абитуриентов
                    if (message.StartsWith("GetEnrollee"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на получение данных абитуриентов");
                        data = Encoding.Unicode.GetBytes(GetEnrollee.GetData(message));
                    }
                    // обновить абитур
                    if (message.StartsWith("UpdateEnrollee"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на одновление абитуриента");
                        data = Encoding.Unicode.GetBytes(UpdateEnrollee.UpdateData(message));
                    }
                    // возвр историю
                    if (message.StartsWith("OutUser"))
                    {
                        data = Encoding.Unicode.GetBytes(StoreUser.OutUser(message));
                    }

                    if (message.StartsWith("GetDoc"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на получение документации");
                        data = Encoding.Unicode.GetBytes(GetLevelEducationSend.GetData());
                    }

                    if (message.StartsWith("GetStateData"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на статические данные");
                        data = Encoding.Unicode.GetBytes(StateData.GetData(message));
                    }

                    if (message.StartsWith("GetLevelEducation"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на уровень образования");
                        data = Encoding.Unicode.GetBytes(GetLevelEducationSend.GetData());
                    }

                    if (message.StartsWith("GetConcessionSend"))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на льготы");
                        data = Encoding.Unicode.GetBytes(GetConcessionSend.GetData());
                    }

                    if (message.StartsWith("DeleteEnrollee "))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на удаления абитуриента");
                        data = Encoding.Unicode.GetBytes(DeleteEnrollee.DeleteEn(message));
                    }
                 
                    // возвращает id посл добавл абит
                    if (message.StartsWith("ReturnLastIdEn "))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на последнего добавленного абитуриента");
                        data = Encoding.Unicode.GetBytes(ReturnLastIdEn.ReturnId());
                    }
              
                          // добавляет доки
                    if (message.StartsWith("AddDoc "))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на добавление документации");
                        data = Encoding.Unicode.GetBytes(AddDoc.AddData(message));
                    }

                    // возвращает докум
                    if (message.StartsWith("GetDoc "))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на вход в документацию");
                        data = Encoding.Unicode.GetBytes(GetDoc.GetData(message));
                    }

                    // удал док
                    if (message.StartsWith("DeleteDoc "))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на удаление документации");
                        data = Encoding.Unicode.GetBytes(DeleteDoc.DeleteByIdDoc(message));
                    }

                    // обнов док
                    if (message.StartsWith("UpdateDoc "))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на обновление документации");
                        data = Encoding.Unicode.GetBytes(UpdateDoc.UpdateData(message));
                    }

                    // возвр историю
                    if (message.StartsWith("GetHis "))
                    {
                        Console.WriteLine($"{DateTime.Now.ToString()}: Запрос на получение документации");
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
