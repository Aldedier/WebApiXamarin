using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CategoriaDAL : CadenaDAL
    {
        public List<CategoriaCLS> ListarCategoria()
        {
            List<CategoriaCLS> lista = new List<CategoriaCLS>();

            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarCategoria", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if(drd != null)
                        {
                            lista = new List<CategoriaCLS>();

                            while (drd.Read())
                            {
                                lista.Add(new CategoriaCLS 
                                {
                                    Id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    Nombre = drd.IsDBNull(1) ? "N/A" : drd.GetString(1),
                                    Descripcion = drd.IsDBNull(2) ? "N/A" : drd.GetString(2)
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

        public int EliminarCategoria(int _id)
        {
            int rpta = 0;

            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCategoria", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", _id);
                        
                        rpta = cmd.ExecuteNonQuery();

                        con.Close();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                    con.Close();
                }
            }

            return rpta;
        }

        public bool GuardarCategoria(CategoriaCLS categoriaCLS)
        {
            bool rpta = false;

            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarCategoria", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", categoriaCLS.Id);
                        cmd.Parameters.AddWithValue("@nombre", categoriaCLS.Nombre);
                        cmd.Parameters.AddWithValue("@descripcion", categoriaCLS.Descripcion);

                        rpta = cmd.ExecuteNonQuery() == 1 ? true : false;

                        con.Close();
                    }
                }
                catch (Exception)
                {
                    rpta = false;
                    con.Close();
                }
            }

            return rpta;
        }
    }
}
