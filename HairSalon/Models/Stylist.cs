using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
        private int _id;
        private string _firstName;
        private string _lastName;

        public Stylist(string firstName, string lastName, int id = 0)
        {
            _id = id;
            _lastName = lastName;
            _firstName = firstName;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (firstName, lastName) VALUES (@FirstName, @Lastname);";

            MySqlParameter firstName = new MySqlParameter;
            firstName.ParameterName = "@FirstName";
            firstName.Value = _firstName;
            cmd.Parameters.Add(firstName);

            MySqlParameter lastName = new MySqlParameter;
            lastName.ParameterName = "@LastName";
            lastName.Value = _lastName;
            cmd.Parameters.Add(lastName);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist)otherStylist;
                bool firstNameEquality = this.GetFirstName().Equals(newStylist.GetFirstName());
                bool lastNameEquality = this.GetLastName().Equals(newStylist.GetLastName());
                bool idEquality = this.GetId().Equals(newStylist.GetId());
                return (firstNameEquality && lastNameEquality && idEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }


    }
}
