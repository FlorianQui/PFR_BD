using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LogicielEscapade
{
    class Connection
    {
        private MySqlConnection connection;

        public MySqlConnection GetSetConnection { get => connection; set => connection = value; }

        public Connection()
        {
            string conStr = "SERVER=localhost;Port=3306;DATABASE=agence_escapade; UID=root; PASSWORD=Flqu970220";
            this.GetSetConnection = new MySqlConnection(conStr);
        }

        public List<string> Select(string table)
        {
            this.GetSetConnection.OpenAsync();

            MySqlCommand req = this.GetSetConnection.CreateCommand();
            req.CommandText = "SELECT * FROM " + table;

            List<string> list = new List<string>();

            MySqlDataReader reader = req.ExecuteReader();

            //this.GetSetConnection.CloseAsync();

            while (reader.Read())
            {
                list.Add(reader.GetString(1));
            }

            return list;
        }
    }
}
