using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerSelectionCommittee
{
    class ClientHttp
    {
        public  void Listen()
        {
            try
            {

                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:3333/connection/");
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
