using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Client
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private int _stylistId;


        public Client(string firstName, string lastName, int stylistId, int id = 0)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _stylistId = stylistId;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }
        public int GetId()
        {
            return _id;
        }
        public int GetStylistId()
        {
            return _stylistId;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (firstName, lastName, stylistId) VALUES (@FirstName, @Lastname, @StylistId);";

            MySqlParameter firstName = new MySqlParameter();
            firstName.ParameterName = "@FirstName";
            firstName.Value = _firstName;
            cmd.Parameters.Add(firstName);

            MySqlParameter lastName = new MySqlParameter();
            lastName.ParameterName = "@LastName";
            lastName.Value = _lastName;
            cmd.Parameters.Add(lastName);

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@StylistId";
            stylistId.Value = _stylistId;
            cmd.Parameters.Add(stylistId);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string firstName = rdr.GetString(1);
                string lastName = rdr.GetString(2);
                int stylistId = rdr.GetInt32(3);
                Client newClient = new Client(firstName, lastName, stylistId, id);
                allClients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allClients;

        }

        public static List<Client> FilteredByStylist(int stylistId)
        {
            List<Client> stylistsClients = new List<Client> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients where stylistId = @StylistId;";

            MySqlParameter selectedId = new MySqlParameter();
            selectedId.ParameterName = "@StylistId";
            selectedId.Value = stylistId;
            cmd.Parameters.Add(selectedId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string firstName = rdr.GetString(1);
                string lastName = rdr.GetString(2);
                int sId = rdr.GetInt32(3);
                Client newClient = new Client(firstName, lastName, sId, id);
                stylistsClients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return stylistsClients;

        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client)otherClient;
                bool firstNameEquality = this.GetFirstName().Equals(newClient.GetFirstName());
                bool lastNameEquality = this.GetLastName().Equals(newClient.GetLastName());
                bool idEquality = this.GetId().Equals(newClient.GetId());
                bool stylistIdEquality = this.GetStylistId().Equals(newClient.GetStylistId());
                return (firstNameEquality && lastNameEquality && idEquality && stylistIdEquality);
            }
        }

        //public override int GetHashCode()
        //{
        //    return this.GetFirstName().GetHashCode();

        //}

    }
}
