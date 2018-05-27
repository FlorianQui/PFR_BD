using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
        public int IdVoiture { get => idVoiture; set => idVoiture = value; }

        public void MettreEnMaintenance(string motif)
        {
            Connection connection = new Connection();
            connection.CommandCount("DELETE FROM stationnement where idVoiture = (select idVoiture from voiture where voiture.immat = '" + this.Immat + "' LIMIT 1);");
            connection.GetSetConnection.Close();

            connection.CommandCount("INSERT INTO `maintenance` (idVoiture,`idControlleur`,`date`,`type_maintenance`) VALUES ((select voiture.idVoiture from voiture where voiture.immat = '" + this.Immat + "'),(select controlleur.idControlleur from controlleur limit 1),'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','" + motif + "');");
            connection.GetSetConnection.Close();
        }

        public void NbMaintenance()
        {
            Connection connection = new Connection();

            MySqlDataReader reader = connection.Command("select count(*) from maintenance where maintenance.idVoiture = (select voiture.idVoiture from voiture where voiture.immat = '" + this.Immat + "');");

            reader.Read();

            Console.WriteLine("NbMaintenance de la voiture immat " + this.Immat + " : " + reader.GetInt32(0));
        }

        public override string ToString()
        {
            return "Immat" + this.Immat;
        }
    }
}
