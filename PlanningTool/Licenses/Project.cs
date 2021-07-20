using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace PlanningTool.Licenses
{
    public class Project
    {
        public ObjectId id;
        public string iconUrl;
        public string progress;
        public string state;
        public string visibility;
        public string name;
        public string version;
        public string downloadUrl;
        public DateTime date;
        public int __v;
    }
}
