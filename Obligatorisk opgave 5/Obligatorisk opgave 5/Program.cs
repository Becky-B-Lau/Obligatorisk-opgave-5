using System.Net.Sockets;
using System.Net;
using Obligatorisk_opgave_5;
using System.Text.Json;

Calculator c = new Calculator();
Console.WriteLine(JsonSerializer.Serialize(c.Add(5, 5))); // Serialiserer resultatet af Add-metoden til JSON
Console.WriteLine(JsonSerializer.Serialize(c.Subtract(5, 5))); // Serialiserer resultatet af Subtract-metoden til JSON
Console.WriteLine(JsonSerializer.Serialize(c.Random(5, 10))); // Serialiserer resultatet af Random-metoden til JSON


TcpListener listener = new TcpListener(IPAddress.Any, 14000);
listener.Start();

while (true)
{
    TcpClient socket = listener.AcceptTcpClient();
    Console.WriteLine("Server activated now");


    EchoService service = new EchoService(socket);
    Task.Run(() => service.HandleClient());
}

listener.Stop();
