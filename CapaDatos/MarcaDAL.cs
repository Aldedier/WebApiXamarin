using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class MarcaDAL : CadenaDAL
    {
        public List<MarcaCLS> ListarMarca()
        {
            List<MarcaCLS> lista = new List<MarcaCLS>();

            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarMarca", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<MarcaCLS>();

                            while (drd.Read())
                            {
                                lista.Add(new MarcaCLS
                                {
                                    Iidmarca = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    Nombre = drd.IsDBNull(1) ? "N/A" : drd.GetString(1),
                                });
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
            }

            return lista;
        }

        public void Algo()
        {

        }
    }
}
