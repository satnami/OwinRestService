using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestOwin.Server;

namespace RestOwin.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new ConnectRest();
            connection.Start();

            while (true) if (System.Console.ReadLine() != "q") { connection.Stop(); }
        }
    }
}
