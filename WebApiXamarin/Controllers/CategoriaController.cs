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
    public class CategoriaController : ApiController
    {
        [HttpGet]
        public List<CategoriaCLS> Get()
        {
            return new CategoriaDAL().ListarCategoria();
        }

        [HttpDelete]
        public int Delete(int _id)
        {
            return new CategoriaDAL().EliminarCategoria(_id);
        }

        [HttpPost]
        public bool Post([FromBody] CategoriaCLS categoriaCLS)
        {
            return new CategoriaDAL().GuardarCategoria(categoriaCLS);
        }

    }
}
