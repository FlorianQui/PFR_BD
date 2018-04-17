using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agence_Escapade
{
    public class Logement
    {
        //TODO Gaetan deserializer reponse json RBNP -> refaire la classe avec les bonnes propriétés etc..  https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm

        private int idLogement, nbVoyageurs;

        private string arrondissement_logement, addresse;

        public Logement()
        {

        }
        public Logement(string arrondissement_logement, string addresse, int nbVoyageurs)
        {
            this.NbVoyageurs = nbVoyageurs;
            this.Arrondissement_logement = arrondissement_logement;
            this.Addresse = addresse;
        }

        public int IdLogement { get => idLogement; set => idLogement = value; }
        public int NbVoyageurs { get => nbVoyageurs; set => nbVoyageurs = value; }
        public string Arrondissement_logement { get => Arrondissement_logement; set => Arrondissement_logement = value; }
        public string Addresse { get => addresse; set => addresse = value; }

        public override string ToString()
        {
            return "[LOCATION] \n" + JsonConvert.SerializeObject(this) + "\n\n";
        }
    }
}
