using Obligatorisk_opgave_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Text.Json;

namespace Obligatorisk_opgave_5
{
    internal class EchoService
    {
        private TcpClient connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            this.connectionSocket = connectionSocket;
        }
        internal void HandleClient()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);
            writer.AutoFlush = true; // enable automatic flushing

            string answer;
            while (true)
            {
                string json = reader.ReadLine();
                Calculator c = new Calculator();

                try
                {
                    JsonDocument document = JsonDocument.Parse(json);
                    JsonElement root = document.RootElement;

                    int n1 = root.GetProperty("n1").GetInt32();
                    int n2 = root.GetProperty("n2").GetInt32();
                    string operation = root.GetProperty("operation").GetString();

                    int m = 0;
                    if (operation == "Random")
                    {
                        m = c.Random(n1, n2);
                    }
                    else if (operation == "Add")
                    {
                        m = c.Add(n1, n2);
                    }
                    else if (operation == "Subtract")
                    {
                        m = c.Subtract(n1, n2);
                    }
                    else
                    {
                        answer = "Invalid operation";
                        writer.WriteLine(answer);
                        continue;
                    }

                    answer = "The answer is: " + m;
                }
                catch (JsonException)
                {
                    answer = "Invalid JSON format";
                }

                writer.WriteLine(answer);
            }

            ns.Close();
            connectionSocket.Close();
        }
    }


}



