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
            List<Specialty> allSpecialtys = new List<Specialty> { };

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
                allSpecialtys.Add(newSpecialty);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allSpecialtys;

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
