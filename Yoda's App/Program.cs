using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yoda_s_App
{
    static class Program
    {
        
     
     [STAThread]
        static void Main()  // The main entry point for the application.
        {
            Server server = new Server();
            server.Start();
        }

    }
}
