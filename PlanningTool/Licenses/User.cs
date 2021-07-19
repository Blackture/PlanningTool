using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace PlanningTool.Licenses
{
    public class User
    {
        public ObjectId id;
        public string title;
        public string titles;
        public string profileIMG;
        public string projectAccess;
        public string username;
        public string firstname;
        public string lastname;
        public string email;
        public string password;
        public string accountType;
        public int accountLevel;
        public string address;
        public string city;
        public string country;
        public DateTime date;
        public int __v;
    }
}
