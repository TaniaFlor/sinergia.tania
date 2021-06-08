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
    public class MedidaController : ApiController
    {
        private ModelSinInventario mcontext = new ModelSinInventario();

        [HttpGet]
        public IEnumerable<IN_MEDIDA> Get()
        {
            List<IN_MEDIDA> listmedida = new List<IN_MEDIDA>();
            SqlParameter paramMedida = null;

            paramMedida = new SqlParameter("@PARAM_ID_MEDIDA", DBNull.Value);
            listmedida = mcontext.Database.SqlQuery<IN_MEDIDA>("dbo.INSP_MEDIDA "
                                                                    , paramMedida).ToList();

            return listmedida;

        }
    }
}
