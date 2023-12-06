using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
public class Example
{
    public static void RecieveDataFromServerExecuteProgram()
    {
        Console.WriteLine("Pipe Client is being executed ...");

        //Receive message from server
        var server = new NamedPipeServerStream("atHome");
        server.WaitForConnection();

        StreamReader reader = new StreamReader(server);
        string msg = reader.ReadLine();

        if (string.IsNullOrEmpty(msg))
            Console.WriteLine("Something went wrong. The client didn't recieve the data.");

        Console.WriteLine("Client recieved the data...");

        var psi = new ProcessStartInfo
        {
            CreateNoWindow = false,
            UseShellExecute = false,
            FileName = msg
        };

        Process process = new Process
        {
            StartInfo = psi
        };
        process.Start();
        process.WaitForExit();

    }

}