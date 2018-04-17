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



namespace Agence_Escapade
{
    public class Sejour
    {
        private Client client;
        private Location location;
        private Logement logement;
        private string theme;
        private bool estConfirme;
        private int note_client, nbVoyageurs, arrondissment_sejour;
        private DateTime date_debut, date_fin;

        public Client Client { get => client; set => client = value; }
        public Location Location { get => location; set => location = value; }
        public Logement Logement { get => logement; set => logement = value; }
        public string Theme { get => theme; set => theme = value; }
        public bool EstConfirme { get => estConfirme; set => estConfirme = value; }
        public int Note_client { get => note_client; set => note_client = value; }
        public int NbVoyageurs { get => nbVoyageurs; set => nbVoyageurs = value; }
        public int Arrondissment_sejour { get => arrondissment_sejour; set => arrondissment_sejour = value; }
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
        }

        public bool CheckVoiture()
        {
            Connection connection = new Connection();

            int resp = connection.CommandCount("select * from voiture where voiture.idVoiture = " +
                "(select idVoiture from stationnement where stationnement.idParking = " +
                "(select parking.idParking from parking where parking.arrondissement_parking = 12)) limit 1;");


            return resp > 0 ? true : false;
        }

        public bool CheckLogement()
        {
            //TODO check logement
            return true;
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

                Console.WriteLine(JsonConvert.SerializeObject(location, Formatting.Indented));

                resp.Close();

                connection.GetSetConnection.Close();

                connection.CommandCount("DELETE FROM stationnement WHERE stationnement.idVoiture = (SELECT idVoiture FROM voiture WHERE immat = '" + voiture.Immat + "');");

                connection.CommandCount("INSERT INTO location (idVoiture) VALUES ( (SELECT idVoiture FROM voiture WHERE immat = '" + voiture.Immat + "'));");


            }
            else Console.WriteLine("Aucune voiture dispo ...");
            connection.GetSetConnection.Close();
        }

    public bool SejourRealisable()
    {
        return this.CheckVoiture() ? true : false;
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
        //if ( this.SejourRealisable() )
        //{
        //    this.BookVoiture();
        //}
        //else Console.WriteLine("Sejour irrealisable");

        this.BookVoiture();
    }

        public override string ToString()
        {
            return "[SEJOUR] \n" + JsonConvert.SerializeObject(this, Formatting.Indented) + "\n\n";
        }
    }
}
