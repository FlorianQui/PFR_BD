using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence_Escapade
{
    public class Voiture
    {
        //TODO Gaetan implementer classe voiture
        private int idVoiture, nbPlaces;
        private string immat, marque, modele, type;

        public Voiture(string immat, string marque, string modele, string type, int nbPlaces)
        {
            this.Immat = immat;
            this.Marque = marque;
            this.Modele = modele;
            this.Type = type;
            this.NbPlaces = nbPlaces;
        }

        public int NbPlaces { get => nbPlaces; set => nbPlaces = value; }
        public string Immat { get => immat; set => immat = value; }
        public string Marque { get => marque; set => marque = value; }
        public string Modele { get => modele; set => modele = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return "Immat" + this.Immat;
        }
    }
}
