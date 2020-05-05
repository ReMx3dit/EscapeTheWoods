using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public static class Global
    {
        public static Log Log = new Log();
        public static DBController DB = new DBController();
    }
}
