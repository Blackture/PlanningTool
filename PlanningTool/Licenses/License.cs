using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace PlanningTool.Licenses
{
    public class License
    {
        public ObjectId _id;
        public ObjectId uuid;
        public bool used;
        public ObjectId project;
        public string[] filters;
    }
}

//60f5f44e095534d8e38ef0ab