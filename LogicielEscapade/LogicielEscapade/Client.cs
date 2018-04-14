using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicielEscapade
{
    class Client
    {
        //TODO Gaetan implementer classe client
        private int idClient;
        private string prenom, nom, telephone, email;

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
    }
}
