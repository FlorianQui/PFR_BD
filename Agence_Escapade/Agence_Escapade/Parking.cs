using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence_Escapade
{
    public class Parking
    {
        //TODO Gaetan implementer classe parking
        private string nom, addresse;
        private int arrondissement_parking;

        public Parking(string nom, string addresse, int arrondissement_parking)
        {
            this.Nom = nom;
            this.Adresse = addresse;
            this.Arrondissement_parking = arrondissement_parking;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => addresse; set => addresse = value; }
        public int Arrondissement_parking { get => arrondissement_parking; set => arrondissement_parking = value; }
    }
}
