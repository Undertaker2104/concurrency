using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
public class Example
{
    public static void SendDataToClient(string name, string path)
    {
        Console.WriteLine("Pipe Server is being executed ...");

        //Send to client
        var client = new NamedPipeClientStream("atHome");
        client.Connect();
        StreamWriter writer = new StreamWriter(client);

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(path))
            Console.WriteLine("One or both of the parameters is empty!");

        Console.WriteLine("Sending data to the client...");
        Console.WriteLine($"Executing {name}...");
        writer.WriteLine(path);
        writer.Flush();


    }
}