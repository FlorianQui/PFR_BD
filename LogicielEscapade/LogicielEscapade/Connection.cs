using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

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

        public List<Client> Select(string table, string critere)
        {
            this.GetSetConnection.Open();

            MySqlCommand req = this.GetSetConnection.CreateCommand();
            req.CommandText = "SELECT " + critere + " FROM " + table;

            Type type = Type.GetType(table);

            //if (type != null)
            //{
                List<Client> list = new List<Client>();
                MySqlDataReader reader = req.ExecuteReader();

                //while (reader.Read())
                //{
                //    object[] arg = new object[reader.FieldCount - 1];
                //    for (int i = 0; i < reader.FieldCount; i++)
                //    {
                //        arg[i] = reader.GetValue(i);
                //    }
                //    dynamic obj = Activator.CreateInstance(type, arg);
                //    list.Add(obj);
                //}

                while(reader.Read())
                {
                    list.Add(new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                }

                this.GetSetConnection.Close();
                return list;
            //}
            //else return null;

            
        }
    }
}
