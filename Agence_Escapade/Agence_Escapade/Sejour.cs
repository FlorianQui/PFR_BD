using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Agence_Escapade
{
    public class Sejour
    {
        private Client client;
        private Location location;
        private Logement logement;
        private string theme;
        private bool estConfirme;
        private int note_client, nbVoyageurs, arrondissment_sejour, idSejour;
        private DateTime date_debut, date_fin;

        public Client Client { get => client; set => client = value; }
        public Location Location { get => location; set => location = value; }
        public Logement Logement { get => logement; set => logement = value; }
        public string Theme { get => theme; set => theme = value; }
        public bool EstConfirme { get => estConfirme; set => estConfirme = value; }
        public int Note_client { get => note_client; set => note_client = value; }
        public int NbVoyageurs { get => nbVoyageurs; set => nbVoyageurs = value; }
        public int Arrondissment_sejour { get => arrondissment_sejour; set => arrondissment_sejour = value; }
        public int IdSejour { get => idSejour; set => idSejour = value; }
        public DateTime Date_debut { get => date_debut; set => date_debut = value; }
        public DateTime Date_fin { get => date_fin; set => date_fin = value; }

        public Sejour()
        {

        }
        public Sejour(Client client, string theme, int arrondissment_sejour, DateTime date_debut, DateTime date_fin)
        {
            this.Client = client;
            this.Theme = theme;
            this.Arrondissment_sejour = arrondissment_sejour;
            this.Date_debut = date_debut;
            this.Date_fin = date_fin;

            EstConfirme = false;
        }

        public bool CheckVoiture()
        {
            Connection connection = new Connection();

            int resp = connection.CommandCount("select * from voiture where voiture.idVoiture = " +
                "(select idVoiture from stationnement where stationnement.idParking = " +
                "(select parking.idParking from parking where parking.arrondissement_parking = 12)) limit 1;");


            return resp > 0 ? true : false;
        }

        public void BookLogement()
        {
            Console.WriteLine("Envois requete to RBNP");
            Console.WriteLine("Reponse from RBNP");
            string listingPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string rbnp = File.ReadAllText(listingPath + "/RBNP.json");

            //Console.WriteLine(rbnp);
            JArray jObject = JArray.Parse(rbnp);
            var logement = from l in jObject
                           where l["availability"].ToString() == "yes" && l["borough"].ToString() == this.Arrondissment_sejour.ToString() && l["bedrooms"].ToString() == "1" && Convert.ToInt32(l["overall_satisfaction"]) >= 4.5
                           select l;

            Logement mylLogement = JsonConvert.DeserializeObject<Logement>(logement.ToList()[0].ToString());
            this.Logement = mylLogement;

            ReponseRBNP reponseRBNP = new ReponseRBNP(this.Logement.Room_id, this.Logement.Room_id);

            Console.WriteLine("[REPONSE RBNP]\n" + reponseRBNP.ToString());
        }

        public void BookVoiture()
        {
            Connection connection = new Connection();

            MySqlDataReader resp = connection.Command("select * from voiture where voiture.idVoiture = " +
                "(select idVoiture from stationnement where stationnement.idParking = " +
                "(select parking.idParking from parking where parking.arrondissement_parking = " + this.Arrondissment_sejour + ")) limit 1;");

            Voiture voiture;
            if (resp.Read())
            {
                Debug.WriteLine("Creation voiture..");
                voiture = new Voiture(resp.GetString(1), resp.GetString(2), resp.GetString(3), resp.GetString(4), resp.GetInt32(5));
                this.Location = new Location(voiture);
                this.Location.IdLocation = resp.GetInt32(0);

                resp.Close();

                connection.GetSetConnection.Close();

                connection.CommandCount("DELETE FROM stationnement WHERE stationnement.idVoiture = (SELECT idVoiture FROM voiture WHERE immat = '" + voiture.Immat + "');");

                connection.CommandCount("INSERT INTO location (idVoiture) VALUES ( (SELECT idVoiture FROM voiture WHERE immat = '" + voiture.Immat + "'));");

                connection.GetSetConnection.Close();
            }
            else
            {
                Console.WriteLine("Aucune voiture dispo dans l'arrondissemnt");

                resp.Close();

                connection.GetSetConnection.Close();

                MySqlDataReader reader = connection.Command("SELECT * FROM voiture WHERE voiture.idVoiture = (SELECT idVoiture FROM stationnement LIMIT 1);");

                if (reader.Read())
                {
                    voiture = new Voiture(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                    this.Location = new Location(voiture);

                    reader.Close();

                    connection.GetSetConnection.Close();

                    connection.CommandCount("DELETE FROM stationnement WHERE stationnement.idVoiture = (SELECT idVoiture FROM voiture WHERE immat = '" + voiture.Immat + "');");

                    connection.CommandCount("INSERT INTO location (idVoiture) VALUES ( (SELECT idVoiture FROM voiture WHERE immat = '" + voiture.Immat + "'));");

                    Console.WriteLine(Location.ToString());

                    reader.Close();

                    connection.GetSetConnection.Close();
                }
                else
                {
                    Console.WriteLine("AUCUNE VOITURE DISPO");
                }
            }
            connection.GetSetConnection.Close();
        }

        public bool SejourRealisable()
        {
            return this.CheckVoiture() ? true : false;
        }

        public void ConfirmationSejourNonConfirme()
        {
            string listingPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            Console.WriteLine(ConfirmationSejourXML());

            File.WriteAllText(listingPath + "/ConfirmationSejourNonConfirme.xml", ConfirmationSejourXML());

            Connection connection = new Connection();

            connection.CommandCount("INSERT INTO sejour (idClient,idLocation,`theme`,`date_debut`,`date_fin`,`arrondissement_sejour`, confirme) VALUES (" +
                "(select client.idClient from client where client.nom = '" + this.Client.Nom + "')," +
                "(select location.idLocation from location where location.idVoiture = (select idVoiture from voiture where voiture.immat = '" + this.Location.Voiture.Immat + "' LIMIT 1) LIMIT 1),'" +
                this.Theme + "','" +
                this.Date_debut.ToString("yyyy-MM-dd HH:mm") + "','" +
                this.Date_fin.ToString("yyyy-MM-dd HH:mm") + "','" +
                this.Arrondissment_sejour + "'," +
                this.EstConfirme.ToString() + ");");

            connection.GetSetConnection.Close();

            MySqlDataReader reader3 = connection.Command("select idSejour from sejour where idClient = (select idClient from client where nom = '" + this.Client.Nom + "') order by idClient DESC limit 1;");

            reader3.Read();
            this.IdSejour = reader3.GetInt32(0);

            Console.WriteLine(this.IdSejour);

            connection.GetSetConnection.Close();

            MySqlDataReader reader2 = connection.Command("select idLocation from sejour where idSejour = '" + this.IdSejour + "'");

            reader2.Read();
            this.Location.IdLocation = reader2.GetInt32(0);

            connection.GetSetConnection.Close();

            Console.WriteLine(this.Location.IdLocation);

            MySqlDataReader reader = connection.Command("select idSejour from sejour where sejour.idLocation = '" + this.Location.IdLocation + "' limit 1;");

            if (reader.Read())
            {
                this.IdSejour = reader.GetInt32(0);
            }
            else
            {
                Console.WriteLine("pb idSejour");
            }
            connection.GetSetConnection.Close();
        }

        public void FinSejour()
        {
            Connection connection = new Connection();

            connection.CommandCount("DELETE FROM sejour WHERE sejour.idSejour = '" + this.IdSejour + "';");

            connection.GetSetConnection.Close();

            connection.CommandCount("DELETE FROM location WHERE location.idVoiture = (select idVoiture from voiture where voiture.immat = '" + this.Location.Voiture.Immat + "');");

            connection.GetSetConnection.Close();

            Connection connection2 = new Connection();

            connection2.CommandCount("insert into stationnement (idParking, idVoiture, numPlace) values ('" + this.Arrondissment_sejour + "', (select idVoiture from voiture where voiture.immat = '" + this.Location.Voiture.Immat + "'), 'A1')");

            connection2.GetSetConnection.Close();

            Console.WriteLine("[FIN SEJOUR]\nMise en stationnement de la voiture sur place A1\nMise en maintenance de la voiture");

            this.Location.Voiture.MettreEnMaintenance("fin sejour");

            
        }

        public string ConfirmationSejourXML()
        {
            return JsonConvert.DeserializeXNode(this.ConfirmationSejourJSON(), "Sejour").ToString();
        }

        public string ConfirmationSejourJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void ConfirmationSejour()
        {
            this.EstConfirme = true;

            ValidationClient validationClient = new ValidationClient(this.IdSejour, this.EstConfirme);
            string validation = JsonConvert.DeserializeXNode(validationClient.ToString(), "ValidationSejour").ToString();

            string listingPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            Console.WriteLine(ConfirmationSejourXML());

            File.WriteAllText(listingPath + "/ConfirmationSejourConfirme.xml", ConfirmationSejourXML());

            Connection connection = new Connection();

            connection.Command("UPDATE sejour SET confirme = 1 where idSejour = '" + this.IdSejour + "';");

            connection.GetSetConnection.Close();
        }

        public override string ToString()
        {
            return "[SEJOUR] \n" + JsonConvert.SerializeObject(this, Formatting.Indented) + "\n\n";
        }
    }

    public class ValidationClient
    {
        private int idSejour;
        private bool confirmation;

        public ValidationClient(int idSejour, bool confirmation)
        {
            this.Confirmation = confirmation;
            this.IdSejour = idSejour;
        }

        public int IdSejour { get => idSejour; set => idSejour = value; }
        public bool Confirmation { get => confirmation; set => confirmation = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class DemandeSejour
    {
        private Client client;
        private Sejour sejour;

        public DemandeSejour(Client client, Sejour sejour)
        {
            this.Client = client;
            this.Sejour = sejour;
        }

        public Client Client { get => client; set => client = value; }
        public Sejour Sejour { get => sejour; set => sejour = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class ReponseRBNP
    {
        private int host_id, room_id;
        private string avaibility;

        public ReponseRBNP(int host_id, int room_id)
        {
            this.Host_id = host_id;
            this.Room_id = room_id;
            this.Avaibility = "no";
        }

        public int Host_id { get => host_id; set => host_id = value; }
        public int Room_id { get => room_id; set => room_id = value; }
        public string Avaibility { get => avaibility; set => avaibility = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
