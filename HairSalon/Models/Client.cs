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
