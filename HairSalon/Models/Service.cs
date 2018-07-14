using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;


namespace HairSalon.Models
{
    public class Service
    {
        private int _id;
        private string _serviceName;

        public Service(string serviceName, int id = 0)
        {
            _id = id;
            _serviceName = serviceName;
        }

        public void Save()
        {
            //MySqlConnection conn = DB.Connection();
            //conn.Open();

            //var cmd = conn.CreateCommand() as MySqlCommand;
            //cmd.CommandText = @"INSERT INTO clients (firstName, lastName, stylistId) VALUES (@FirstName, @Lastname, @StylistId);";

            //MySqlParameter firstName = new MySqlParameter();
            //firstName.ParameterName = "@FirstName";
            //firstName.Value = _firstName;
            //cmd.Parameters.Add(firstName);

            //MySqlParameter lastName = new MySqlParameter();
            //lastName.ParameterName = "@LastName";
            //lastName.Value = _lastName;
            //cmd.Parameters.Add(lastName);

            //MySqlParameter stylistId = new MySqlParameter();
            //stylistId.ParameterName = "@StylistId";
            //stylistId.Value = _stylistId;
            //cmd.Parameters.Add(stylistId);

            //cmd.ExecuteNonQuery();
            //_id = (int)cmd.LastInsertedId;

            //conn.Close();
            //if (conn != null)
            //{
            //    conn.Dispose();
            //}

        }

        public static List<Service> GetAll()
        {
            List<Service> allServices = new List<Service> { };

            //MySqlConnection conn = DB.Connection();
            //conn.Open();

            //var cmd = conn.CreateCommand() as MySqlCommand;
            //cmd.CommandText = @"SELECT * FROM clients;";

            //MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            //while (rdr.Read())
            //{
            //    int id = rdr.GetInt32(0);
            //    string firstName = rdr.GetString(1);
            //    string lastName = rdr.GetString(2);
            //    int stylistId = rdr.GetInt32(3);
            //    Client newClient = new Client(firstName, lastName, stylistId, id);
            //    allClients.Add(newClient);
            //}

            //conn.Close();
            //if (conn != null)
            //{
            //    conn.Dispose();
            //}

            return allServices;

        }


        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM services;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
