﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net;



namespace ServerSelectionCommittee
{
    class Program
    {
        static TcpListener listener;

        static void Main(string[] args)
        {
            //try
            //{
            //    listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
            //    listener.Start();
            //    Console.WriteLine("Ожидание подключений...");
            //    while (true)
            //    {
            //        TcpClient client = listener.AcceptTcpClient();
            //        ClientObject clientObject = new ClientObject(client);
            //        // Создаем новый поток для обслуживания нового клиента
            //        Thread clientThread = new Thread(new
            //       ThreadStart(clientObject.Process));
            //        clientThread.Start();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    if (listener != null)
            //        listener.Stop();
            //}

            List<DocumentsSend> doc = null;

            // десериализация
            using (FileStream fs = new FileStream("SerializableFile/DocumentsSend.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<DocumentsSend>));

                doc = (List<DocumentsSend>)formatter.Deserialize(fs);

                foreach (DocumentsSend s in doc)
                {
                    Console.WriteLine($"id: {s.Id}; описание: {s.Description}; номер: {s.NumberDocument}");
                }

                Console.ReadKey();
            }
        }
    }
}
