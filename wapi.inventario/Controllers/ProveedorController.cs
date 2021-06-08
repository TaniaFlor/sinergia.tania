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
    public class ProveedorController : ApiController
    {
        private ModelSinInventario mcontext = new ModelSinInventario();

        [HttpGet]
        public IEnumerable<IN_PROVEEDOR> Get()
        {

            List<IN_PROVEEDOR> listproveedor = new List<IN_PROVEEDOR>();

            SqlParameter paramProveedor = null;

            paramProveedor = new SqlParameter("@PARAM_ID_PROVEEDOR", DBNull.Value);
            listproveedor = mcontext.Database.SqlQuery<IN_PROVEEDOR>("dbo.INSP_PROVEEDOR "
                                                                    , paramProveedor).ToList();

            return listproveedor;

        }
    }
}
