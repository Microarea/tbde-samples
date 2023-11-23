
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
     
        static void Main(string[] args)
        {
            if (args == null || args.Length < 4)
            {
                Console.WriteLine("Missing 4 parameters!");
                return;
            }
             string beInstance = args[0];
            string user = args[1];
            string pwd = args[2];
            string subKey = args[3];

            bool b = MyClient.Execute(beInstance, user, pwd, subKey);
        }
    }
}
