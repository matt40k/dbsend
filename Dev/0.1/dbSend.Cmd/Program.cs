using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbSend.Process;

namespace dbSend.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            // Invoke dbSend class
            Entry entry = new Entry();

            string testFile = @"C:\Windows\system32\drivers\etc\hosts";

            Console.WriteLine(entry.SetUploadFile(testFile));
            Console.WriteLine(entry.GetRandomPassword);
            Console.WriteLine(entry.DoIt);
            Console.ReadKey();
        }
    }
}
