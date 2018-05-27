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
            Client c = new Client(1, "Junot", "Gerard", "0", "");
            Sejour sejour = new Sejour(c, "theme", 16, DateTime.Now, DateTime.Now);

            Console.WriteLine("[CHECK CLIENT]\n\n");
            c.CheckClient();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("[BOOK VOITURE]\n\n");
            sejour.BookVoiture();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("[BOOK LOGEMENT]\n\n");
            sejour.BookLogement();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("[CONFIRMATION NON CONFIRME]\n\n");
            sejour.ConfirmationSejourNonConfirme();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("[VALIDATION SEJOUR]\n\n");
            sejour.ConfirmationSejour();
            Console.ReadKey();
            Console.Clear();
        }

        //public static void
    }
}
