using System;
using System.Diagnostics;

namespace Exercise
{
    public class ProcessCreation
    {
        public virtual void createProcess()
        {
            Console.WriteLine("\n\nDir command:\n\n");
            var psi = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = @"C:\Users\milan"
            };

            Process process = new Process() { StartInfo = psi };
            process.StartInfo.FileName = "cmd.exe";
            process.Start();
            process.StandardInput.WriteLine("dir");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());

            try
            {
                // Execute a simple command (e.g., dir)

                //Console.WriteLine(process.StandardOutput.ReadToEnd());

                // Run the compiled version of the Processes project
                Console.WriteLine("\n\nProcesses file:\n\n");
                var psi2 = new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,

                    FileName = @"C:\Users\milan\OneDrive\Documenten\GitHub\concurrency\Processes\bin\Debug\net6.0\Processes.exe"
                };

                Process process2 = new Process
                {
                    StartInfo = psi2
                };
                process2.Start();
                process2.WaitForExit();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
    }
}



