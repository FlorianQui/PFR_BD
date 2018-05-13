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
            Client c = new Client(1, "Junot", "Gerard", "0", null);
            Sejour sejour = new Sejour(c, "theme", 16, DateTime.Now, DateTime.Now);

            //Console.Write(c.isClient());

            //c.CheckClient();

            //sejour.BookVoiture();
            sejour.BookLogement();

            //Console.WriteLine(sejour.CheckVoiture());

           

            
            Console.ReadKey();
        }

        //public static void
    }
}
