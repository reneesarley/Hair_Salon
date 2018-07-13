using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

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

    }
}
