using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;

namespace Exercise
{
    public class IPCNamedClient
    {
        public virtual void ipcClientCommunicate()
        {
            Console.WriteLine("Pipe Client is being executed ...");
            Console.WriteLine("[Client] waiting to receive a message");
            //Receive message from server
            var server = new NamedPipeServerStream("PipesOfConcurrency");
            server.WaitForConnection();
            //read from server
            StreamReader reader = new StreamReader(server);

            //Send it back to server
            var client = new NamedPipeClientStream("PipesOfConcurrency1");
            client.Connect();
            StreamWriter writer = new StreamWriter(client);
            while (true)
            {

                String msg = reader.ReadLine();
                if (String.IsNullOrEmpty(msg))
                    break;

                else
                {
                    Console.WriteLine("message recieved");
                    Console.WriteLine("Sending it back..");
                    writer.WriteLine(msg);
                    writer.Flush();
                }

            }
        }
    }
}