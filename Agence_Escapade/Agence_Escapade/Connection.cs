using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Agence_Escapade
{
    class Connection
    {
        private MySqlConnection connection;

        public MySqlConnection GetSetConnection { get => connection; set => connection = value; }

        public Connection()
        {
            string conStr = "SERVER=localhost;Port=3306;DATABASE=agence_escapade; UID=root; PASSWORD=Flqu970220; SslMode=none";
            this.GetSetConnection = new MySqlConnection(conStr);
        }

        public MySqlDataReader Command(string req)
        {
            this.GetSetConnection.Open();

            MySqlCommand command = this.GetSetConnection.CreateCommand();

            command.CommandText = req;

            MySqlDataReader dataReader = command.ExecuteReader();

            return dataReader;
        }

        public int CommandCount(string req)
        {
            MySqlDataReader reader = this.Command(req);

            int result = 0;

            while (reader.Read()) result++;

            reader.Close();

            this.GetSetConnection.Close();

            return result;
        }
    }
}
