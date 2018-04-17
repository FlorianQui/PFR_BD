using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Agence_Escapade
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client(98, "flo", "qui","09", null);
            Sejour sejour = new Sejour(c, "theme", 1, DateTime.Now, DateTime.Now);

            //Console.WriteLine(sejour.CheckVoiture());

           

            
            Console.ReadKey();
        }
    }
}
