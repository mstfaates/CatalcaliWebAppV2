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
        public static DataContext Db = null;
        public static DataContext GetConnection()
        {
            if (Db == null)
            {
                Db = new DataContext();
            }
            return Db;
        }
    }
}
