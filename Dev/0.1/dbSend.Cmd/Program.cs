using System;

namespace dbSend.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Reference
            Reference reference = new Reference();

            // Load args into reference
            ReadArgs readArgs = new ReadArgs(reference);
            readArgs.Read(args);

            // Load Worker
            Worker worker = new Worker(reference);
            Console.WriteLine(worker.DoIt);
        }
    }
}
