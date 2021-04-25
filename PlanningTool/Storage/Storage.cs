using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.Storage
{
    [Serializable]
    public class Storage
    {
        public List<StorageItem> films = null;

        public void Add(Film film)
        {
            films.Add(film);
        }
    }
}
