using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ProductoDAL : CadenaDAL
    {
        public int EliminarProducto(int _id)
        {
            int rpta = 0;

            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidproducto", _id);

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

        public List<ProductoCLS> ListarProducto()
        {
            List<ProductoCLS> lista = new List<ProductoCLS>();

            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarProductos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();

                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();

                            while (drd.Read())
                            {
                                lista.Add(new ProductoCLS
                                {
                                    IdProducto = drd.IsDBNull(0) ? 0 : drd.GetInt32(0),
                                    Nombre = drd.IsDBNull(1) ? "N/A" : drd.GetString(1),
                                    Precio = drd.IsDBNull(2) ? 0 : drd.GetDecimal(2),
                                    Stock = drd.IsDBNull(3) ? 0 : drd.GetInt32(3),
                                    NombreCategoria = drd.IsDBNull(4) ? "N/A" : drd.GetString(4),
                                    NombreMarca = drd.IsDBNull(5) ? "N/A" : drd.GetString(5)
                                });
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                }
            }

            return lista;
        }

        public bool GuardarProducto(ProductoCLS productoCLS)
        {
            bool rpta = false;

            //string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(Cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarProducto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidproducto", productoCLS.IdProducto);
                        cmd.Parameters.AddWithValue("@nombre", productoCLS.Nombre);
                        cmd.Parameters.AddWithValue("@precio", productoCLS.Precio);
                        cmd.Parameters.AddWithValue("@idcategoria", productoCLS.IdCategoria);
                        cmd.Parameters.AddWithValue("@stock", productoCLS.Stock);
                        cmd.Parameters.AddWithValue("@iidmarca", productoCLS.IdMarca);

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
