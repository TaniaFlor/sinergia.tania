using entidad.inventario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace wapi.inventario.Controllers
{
    public class CategoriaController : ApiController
    {
        private ModelSinInventario mcontext = new ModelSinInventario();

        [HttpGet]
        public IEnumerable<IN_CATEGORIA> Get()
        {
            List<IN_CATEGORIA> listcategoria = new List<IN_CATEGORIA>();

            SqlParameter paramCategoria = null;

            paramCategoria = new SqlParameter("@PARAM_ID_CATEGORIA", DBNull.Value);
            listcategoria = mcontext.Database.SqlQuery<IN_CATEGORIA>("dbo.INSP_CATEGORIA "
                                                                    , paramCategoria).ToList();

            return listcategoria;

        }
    }
}
