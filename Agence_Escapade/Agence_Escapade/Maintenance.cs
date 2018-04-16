using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence_Escapade
{
    public class Maintenance
    {
        //TODO Gaetan implementer classe maintenance
        private Controlleur controlleur;
        private DateTime date;
        private string typeMaintenance;

        public Maintenance(Controlleur controlleur, DateTime date, string typeMaintenance)
        {
            this.Controlleur = controlleur;
            this.Date = date;
            this.TypeMaintenance = typeMaintenance;
        }

        public DateTime Date { get => date; set => date = value; }
        public string TypeMaintenance { get => typeMaintenance; set => typeMaintenance = value; }
        internal Controlleur Controlleur { get => controlleur; set => controlleur = value; }

        
    }
}
