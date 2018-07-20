using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int id { get; set; }
        private string _firstName;
        private string _lastName;

        public Stylist(string firstName, string lastName, int stylistId = 0)
        {
            id = stylistId;
            _lastName = lastName;
            _firstName = firstName;
        }

        //public int GetId()
        //{
        //    return _id;
        //}

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetFirstAndLastName()
        {
            return _firstName + " " + _lastName;
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string firstName = rdr.GetString(1);
                string lastName = rdr.GetString(2);
                Stylist newStylist = new Stylist(firstName, lastName, id);
                allStylists.Add(newStylist);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allStylists;
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @ThisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@ThisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int stylistId = 0;
            string firstName = "";
            string lastName = "";

            while (rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                firstName = rdr.GetString(1);
                lastName = rdr.GetString(2);
            }

            Stylist foundStylist = new Stylist(firstName, lastName, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundStylist;

        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (firstName, lastName) VALUES (@FirstName, @Lastname);";

            MySqlParameter firstName = new MySqlParameter();
            firstName.ParameterName = "@FirstName";
            firstName.Value = _firstName;
            cmd.Parameters.Add(firstName);

            MySqlParameter lastName = new MySqlParameter();
            lastName.ParameterName = "@LastName";
            lastName.Value = _lastName;
            cmd.Parameters.Add(lastName);

            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_Specialties (stylist_id, Specialty_id) VALUES (@StylistId, @SpecialtyId);";

            MySqlParameter Specialty_id = new MySqlParameter();
            Specialty_id.ParameterName = "@SpecialtyId";
            Specialty_id.Value = newSpecialty.GetSpecialtyId();
            cmd.Parameters.Add(Specialty_id);

            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@StylistId";
            stylist_id.Value = id;
            cmd.Parameters.Add(stylist_id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public List<Specialty> GetSpecialties()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT Specialty_id FROM stylists_Specialties WHERE stylist_id = @StylistId;";

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@StylistId";
            stylistId.Value = id;
            cmd.Parameters.Add(stylistId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            List<int> SpecialtyIds = new List<int> { };
            while (rdr.Read())
            {
                int SpecialtyId = rdr.GetInt32(0);
                SpecialtyIds.Add(SpecialtyId);
            }
            rdr.Dispose();

            List<Specialty> Specialties = new List<Specialty> { };
            foreach (int SpecialtyId in SpecialtyIds)
            {
                var SpecialtyQuery = conn.CreateCommand() as MySqlCommand;
                SpecialtyQuery.CommandText = @"SELECT * FROM Specialties WHERE id = @SpecialtyId;";

                MySqlParameter SpecialtyIdParameter = new MySqlParameter();
                SpecialtyIdParameter.ParameterName = "@SpecialtyId";
                SpecialtyIdParameter.Value = SpecialtyId;
                SpecialtyQuery.Parameters.Add(SpecialtyIdParameter);

                var SpecialtyQueryRdr = SpecialtyQuery.ExecuteReader() as MySqlDataReader;
                while (SpecialtyQueryRdr.Read())
                {
                    int thisSpecialtyId = SpecialtyQueryRdr.GetInt32(0);
                    string SpecialtyName = SpecialtyQueryRdr.GetString(1);
                    Specialty foundSpecialty = new Specialty(SpecialtyName, thisSpecialtyId);
                    Specialties.Add(foundSpecialty);
                }
                SpecialtyQueryRdr.Dispose();
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return Specialties;
        }

    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";

        cmd.ExecuteNonQuery();

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists where id = @StylistId;";
           
            cmd.Parameters.AddWithValue("@StylistId", id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static void Update(string newFirstName, string newLastName, int stylistId)
        {

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET firstName = @NewFirstName, lastName = @NewLastName WHERE id = @StylistId";

            cmd.Parameters.AddWithValue("@NewFirstName", newFirstName);
            cmd.Parameters.AddWithValue("@NewLastName", newLastName);
            cmd.Parameters.AddWithValue("@StylistId", stylistId);

            cmd.ExecuteNonQuery();

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
            return (firstNameEquality && lastNameEquality);
        }
    }

    public override int GetHashCode()
    {
        return this.GetFirstName().GetHashCode();

    }


}
}
