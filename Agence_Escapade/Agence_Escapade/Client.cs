using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agence_Escapade
{
    public class Client
    {
        //TODO Gaetan implementer classe client
        private int idClient;
        private string prenom, nom, telephone, email;

        public Client()
        {

        }
        public Client(int idClient, string nom, string prenom, string telephone, string email)
        {
            this.IdClient = idClient;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Telephone = telephone;
            this.Email = email;
        }

        public int IdClient { get => idClient; set => idClient = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }

        public override string ToString()
        {
            return "[CLIENT] \n" + JsonConvert.SerializeObject(this) + "\n\n";
        }

        public bool isClient()
        {
            bool result = false;
            Connection connection = new Connection();

            if (connection.CommandCount("SELECT * FROM client where nom = '" + this.Nom + "'") >= 1) result = true;

            return result;
        }

        public void CheckClient()
        {
            if( !isClient() )
            {
                Connection connection = new Connection();
                connection.Command("INSERT INTO client (nom, prenom, telephone, email) VALUES ('" + this.Nom + "','" + this.Prenom + "','" + this.Telephone + "','" + this.Email + "');");
            }
        }
    }
}
