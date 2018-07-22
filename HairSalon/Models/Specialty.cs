using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;


namespace HairSalon.Models
{
    public class Specialty
    {
        private int _id;
        private string _specialtyName;

        public Specialty(string specialtyName, int id = 0)
        {
            _id = id;
            _specialtyName = specialtyName;
        }

        public int GetSpecialtyId()
        {
            return _id;
        }

        public string GetSpecialtyName()
        {
            return _specialtyName;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (specialtyName) VALUES (@SpecialtyName);";

            MySqlParameter specialtyName = new MySqlParameter();
            specialtyName.ParameterName = "@SpecialtyName";
            specialtyName.Value = _specialtyName;
            cmd.Parameters.Add(specialtyName);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(specialtyName, id);
                allSpecialties.Add(newSpecialty);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allSpecialties;

        }
        public static List<Specialty> GetAllForStylist(int stylistId)
        {
            List<Specialty> allSpecialties = new List<Specialty> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialties.* FROM stylists_specialties JOIN specialties ON (stylists_specialties.specialty_id = specialties.id) WHERE stylists_specialties.stylist_id = @StylistID;";
    
            cmd.Parameters.AddWithValue("@StylistID", stylistId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int idRdr = rdr.GetInt32(0);
                string specialtyNameRdr = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(specialtyNameRdr, idRdr);
                allSpecialties.Add(newSpecialty);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allSpecialties;

        }


        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAllSpecialtiesForSylist(int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists_specialties WHERE stylist_id = @StylistId;";

            cmd.Parameters.AddWithValue("@StylistId", stylistId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool specialtyNameEquality = this.GetSpecialtyName().Equals(newSpecialty.GetSpecialtyName());
                return (specialtyNameEquality);
            }
        }
    }
}
