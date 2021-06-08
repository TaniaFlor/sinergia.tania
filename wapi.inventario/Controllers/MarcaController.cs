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
    public class MarcaController : ApiController
    {
        private ModelSinInventario mcontext = new ModelSinInventario();

        [HttpGet]
        public IEnumerable<IN_MARCA> Get()
        {
            List<IN_MARCA> listmarca = new List<IN_MARCA>();

            SqlParameter paramMARCA = null;

            paramMARCA = new SqlParameter("@PARAM_ID_MARCA", DBNull.Value);
            listmarca = mcontext.Database.SqlQuery<IN_MARCA>("dbo.INSP_MARCA "
                                                                    , paramMARCA).ToList();

            return listmarca;

        }
    }
}
