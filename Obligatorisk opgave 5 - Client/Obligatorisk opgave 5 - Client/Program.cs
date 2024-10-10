using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;

TcpClient clientSocket = new TcpClient("127.0.0.1", 14000);
Console.WriteLine("client is ready");

Stream ns = clientSocket.GetStream();
StreamReader sr = new StreamReader(ns);
StreamWriter sw = new StreamWriter(ns);
sw.AutoFlush = true;

while (true)
{
    Console.WriteLine("Enter first number, second number, and operation (Random, Add, Subtract): ");
    string input = Console.ReadLine();
    string[] inputs = input.Split(' ');

    int n1 = int.Parse(inputs[0]);
    int n2 = int.Parse(inputs[1]);
    string operation = inputs[2];

    // Create JSON object
    var jsonObject = new
    {
        n1 = n1,
        n2 = n2,
        operation = operation
    };

    string json = JsonSerializer.Serialize(jsonObject);

    // Send JSON object to server
    sw.WriteLine(json);

    // Receive and display server's response
    string response = sr.ReadLine();
    Console.WriteLine(response);
}

ns.Close();
clientSocket.Close();
