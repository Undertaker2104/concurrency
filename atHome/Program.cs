
public class Program
{
    public static void Main()
    {
        //Example is server
        string fileName = "Processes.exe";
        string filePath = @"C:\Users\milan\OneDrive\Documenten\GitHub\concurrency\Processes\bin\Debug\net6.0\Processes.exe";

        Example.SendDataToClient(fileName, filePath);

        //Example2 is client
    }
}

