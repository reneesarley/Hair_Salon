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

        public string GetServiceName()
        {
            return _serviceName;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO services (serviceName) VALUES (@ServiceName);";

            MySqlParameter serviceName = new MySqlParameter();
            serviceName.ParameterName = "@ServiceName";
            serviceName.Value = _serviceName;
            cmd.Parameters.Add(serviceName);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public static List<Service> GetAll()
        {
            List<Service> allServices = new List<Service> { };

            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM services;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string serviceName = rdr.GetString(1);
                Service newService = new Service(serviceName, id);
                allServices.Add(newService);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

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
        public override bool Equals(System.Object otherService)
        {
            if (!(otherService is Service))
            {
                return false;
            }
            else
            {
                Service newService = (Service)otherService;
                bool serviceNameEquality = this.GetServiceName().Equals(newService.GetServiceName());
                return (serviceNameEquality);
            }
        }
    }
}
