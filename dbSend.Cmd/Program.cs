using System;

namespace dbSend.Cmd
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create Reference
            var reference = new Reference();

            // Load args into reference
            var readArgs = new ReadArgs(reference);
            readArgs.Read(args);

            // Load Worker
            var worker = new Worker(reference);
            Console.WriteLine(worker.DoIt);

            Console.ReadKey();
        }
    }
}