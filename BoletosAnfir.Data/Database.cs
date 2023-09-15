using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosAnfir.Data
{
    public static class Database
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["anfir"].ConnectionString;
            }
        }
    }
}
