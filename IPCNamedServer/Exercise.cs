using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;

namespace Exercise
{
    public class IPCNamedServer
    {
        public virtual void ipcServerCommunicate()
        {
            Console.WriteLine("Pipe Server is being executed ...");
            Console.WriteLine("[Server] Enter a message to be reversed by the client (press ENTER to exit)");

            //Send to client
            var client = new NamedPipeClientStream("PipesOfConcurrency");
            //Recieve back from client
            var server = new NamedPipeServerStream("PipesOfConcurrency1");
            client.Connect();


            StreamWriter writer = new StreamWriter(client);

            //Send message to client
            while (true)
            {

                String input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                    break;

                else
                {
                    Console.WriteLine("\n\nSending message to client");
                    writer.WriteLine(input);
                    writer.Flush();
                    break;
                }


            }

            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            //Receive message back from client
            while (true)
            {

                String msg = reader.ReadLine();
                if (String.IsNullOrEmpty(msg)) // Finish if nothing is entered
                    break;
                else
                {
                    Console.WriteLine("\n\nMessage went back to server");
                    Console.WriteLine(msg); // Print the message received
                    Console.WriteLine(String.Join("", msg.Reverse())); // Print the reverse of the received message

                }
                break;
            }

        }
    }
}