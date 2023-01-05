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
    public class ProductoController : ApiController
    {
        [HttpGet]
        public List<ProductoCLS> Get()
        {
            return new ProductoDAL().ListarProducto();
        }

        [HttpDelete]
        public int Delete(int _id)
        {
            return new ProductoDAL().EliminarProducto(_id);
        }

        [HttpPost]
        public bool Post([FromBody] ProductoCLS productoCLS)
        {
            return new ProductoDAL().GuardarProducto(productoCLS);
        }
    }
}
