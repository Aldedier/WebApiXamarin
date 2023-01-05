using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiXamarin.Controllers
{
    public class CategoriaMarcaController : ApiController
    {
        public CategoriaMarcaCLS Get()
        {
            CategoriaMarcaCLS obj = new CategoriaMarcaCLS();
            obj.ListaMarca = new MarcaDAL().ListarMarca();
            obj.ListaCategoria = new CategoriaDAL().ListarCategoria();
            return obj;
        }
    }
}
