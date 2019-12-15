using System;
using System.IO;
using System.Net;

namespace ServerSelectionCommittee
{
    class ClientHttp
    {
        public  void Listen()
        {
            try
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:3333/monitoring/");
                listener.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    string responseString =CreateView.GetView();
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
