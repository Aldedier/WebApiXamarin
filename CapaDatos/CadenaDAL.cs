using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CadenaDAL
    {
        public string Cadena { get; set; }

        public CadenaDAL()
        {
            Cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
    }
}
