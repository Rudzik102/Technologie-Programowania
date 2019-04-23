using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    class DataContext
    {
        public AdventureClassesDataContext db;

        public DataContext()
        {
            db = new AdventureClassesDataContext();
        }
    }
}
