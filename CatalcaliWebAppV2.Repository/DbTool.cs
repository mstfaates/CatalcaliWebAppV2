using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalcaliWebAppV2.Repository
{
    public class DbTool
    {
        public static DataContext db = null;
        public static DataContext GetConnection()
        {
            if (db == null)
            {
                db = new DataContext();
            }
            return db;
        }
    }
}
