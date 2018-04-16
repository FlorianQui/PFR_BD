using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence_Escapade
{
    public class Location
    {
        //TODO Gaetan implementer classe location
        private int idLocation;
        private Voiture voiture;

        public Location()
        {

        }
        public Location(Voiture voiture)
        {
            this.Voiture = voiture;
        }

        public int IdLocation { get => idLocation; set => idLocation = value; }
        public Voiture Voiture { get => voiture; set => voiture = value; }
    }
}
