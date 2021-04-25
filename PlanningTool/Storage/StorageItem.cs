using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.Storage
{
    [Serializable]
    public abstract class StorageItem
    {
        private static List<int> usedIds = new List<int>();

        private string id;

        public string ID
        {
            get { return id; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private DateTime releaseDate;

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public StorageItem()
        {
            id = generateID();
        }

        public StorageItem(string _id)
        {
            id = _id;
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        public abstract string GetGenres();
    }
}
