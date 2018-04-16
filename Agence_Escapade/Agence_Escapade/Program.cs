using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace Agence_Escapade
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client(98, "flo", "qui","09", null);
            Sejour sejour = new Sejour(c, "theme",12 , DateTime.Now, DateTime.Now);

            sejour.BookVoiture();

            //sejour.ConfirmationSejour();

            Console.WriteLine(sejour.ConfirmationSejourJSON());

            
            Console.ReadKey();
        }
    }
}
