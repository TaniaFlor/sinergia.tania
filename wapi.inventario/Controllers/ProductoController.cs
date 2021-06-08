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
    public class ProductoController : ApiController
    {
        private ModelSinInventario contexto = new ModelSinInventario();

        [HttpGet]
        public IEnumerable<IN_PRODUCTO> Get()
        {
            List<IN_PRODUCTO> listProductos;
            IN_MARCA inmarca = new IN_MARCA();
            IN_CATEGORIA incategoria = new IN_CATEGORIA();
            IN_MEDIDA inmedida = new IN_MEDIDA();
            IN_PROVEEDOR inproveedor = new IN_PROVEEDOR();

            SqlParameter paramMarca = null;
            SqlParameter paramCategoria = null;
            SqlParameter paramMedida = null;
            SqlParameter paramProveedor = null;

            listProductos = contexto.Database.SqlQuery<IN_PRODUCTO>("dbo.INSP_PRODUCTO ").ToList();
            foreach (IN_PRODUCTO item in listProductos)
            {
                paramMarca = new SqlParameter("@PARA_ID_MARCA", item.IN_MARCA_ID);
                inmarca = contexto.Database.SqlQuery<IN_MARCA>("dbo.INSP_MARCA @PARA_ID_MARCA "
                                                                    , paramMarca).ToList().FirstOrDefault();

                paramCategoria = new SqlParameter("@PARA_ID_CATEGORIA", item.IN_CATEGORIA_ID);
                incategoria = contexto.Database.SqlQuery<IN_CATEGORIA>("dbo.INSP_CATEGORIA @PARA_ID_CATEGORIA "
                                                                    , paramCategoria).ToList().FirstOrDefault();

                paramMedida = new SqlParameter("@PARA_ID_MEDIDA", item.IN_MEDIDA_ID);
                inmedida = contexto.Database.SqlQuery<IN_MEDIDA>("dbo.INSP_MEDIDA @PARA_ID_MEDIDA "
                                                                    , paramMedida).ToList().FirstOrDefault();

                paramProveedor = new SqlParameter("@PARA_ID_PROVEEDOR", item.IN_PROVEEDOR_ID);
                inproveedor = contexto.Database.SqlQuery<IN_PROVEEDOR>("dbo.INSP_PROVEEDOR @PARA_ID_PROVEEDOR"
                                                                    , paramProveedor).ToList().FirstOrDefault();


                listProductos.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_MARCA = inmarca;

                listProductos.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_CATEGORIA = incategoria;
                listProductos.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_MEDIDA = inmedida;
                listProductos.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_PROVEEDOR = inproveedor;

            }

            return listProductos;

        }

        [HttpGet]
        public IN_PRODUCTO Get(int id)
        {
            List<IN_PRODUCTO> listProducto;
            IN_PRODUCTO prod;

            IN_MARCA inmarca = new IN_MARCA();
            IN_CATEGORIA incategoria = new IN_CATEGORIA();
            IN_MEDIDA inmedida = new IN_MEDIDA();
            IN_PROVEEDOR inproveedor = new IN_PROVEEDOR();

            SqlParameter paramProducto = null;

            SqlParameter paramMarca = null;
            SqlParameter paramCategoria = null;
            SqlParameter paramMedida = null;
            SqlParameter paramProveedor = null;

            paramProducto = new SqlParameter("@PARAM_ID_PRODUCTO", id);
            listProducto = contexto.Database.SqlQuery<IN_PRODUCTO>("dbo.INSP_PRODUCTO @PARAM_ID_PRODUCTO"
                                                                    , paramProducto).ToList();
            foreach (IN_PRODUCTO item in listProducto)
            {
                paramMarca = new SqlParameter("@PARAM_ID_MARCA", item.IN_MARCA_ID);
                inmarca = contexto.Database.SqlQuery<IN_MARCA>("dbo.INSP_MARCA @PARAM_ID_MARCA "
                                                                    , paramMarca).ToList().FirstOrDefault();

                paramCategoria = new SqlParameter("@PARAM_ID_CATEGORIA", item.IN_CATEGORIA_ID);
                incategoria = contexto.Database.SqlQuery<IN_CATEGORIA>("dbo.INSP_CATEGORIA @PARAM_ID_CATEGORIA "
                                                                    , paramCategoria).ToList().FirstOrDefault();

                paramMedida = new SqlParameter("@PARAM_ID_MEDIDA", item.IN_MEDIDA_ID);
                inmedida = contexto.Database.SqlQuery<IN_MEDIDA>("dbo.INSP_MEDIDA @PARAM_ID_MEDIDA "
                                                                    , paramMedida).ToList().FirstOrDefault();

                paramProveedor = new SqlParameter("@PARAM_ID_PROVEEDOR", item.IN_PROVEEDOR_ID);
                inproveedor = contexto.Database.SqlQuery<IN_PROVEEDOR>("dbo.INSP_PROVEEDOR @PARAM_ID_PROVEEDOR "
                                                                    , paramProveedor).ToList().FirstOrDefault();


                listProducto.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_MARCA = inmarca;

                listProducto.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_CATEGORIA = incategoria;
                listProducto.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_MEDIDA = inmedida;
                listProducto.Find(x => x.IN_PRODUCTO_ID == item.IN_PRODUCTO_ID).IN_PROVEEDOR = inproveedor;

            }

            prod = listProducto.FirstOrDefault();

            return prod;

        }

        [HttpPost]
        public IHttpActionResult nuevoproducto([FromBody]IN_PRODUCTO pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contexto.IN_PRODUCTO.Add(pro);
                    contexto.SaveChanges();
                    return Ok(pro);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult actualizarproducto(string id, [FromBody]IN_PRODUCTO pro)
        {
            if (ModelState.IsValid)
            {
                IN_PRODUCTO prodExist = null;

                prodExist = (from prod in contexto.IN_PRODUCTO
                              where prod.IN_PRODUCTO_CODIGO == id
                              select prod).ToList().FirstOrDefault();
                if (prodExist != null)
                {

                    try
                    {

                        prodExist.IN_CANTIDAD = pro.IN_CANTIDAD;
                        prodExist.IN_PRECIO_UNITARIO = pro.IN_PRECIO_UNITARIO;
                        prodExist.IN_DESCRIPCION = pro.IN_DESCRIPCION;
                        prodExist.IN_CATEGORIA_ID = pro.IN_CATEGORIA_ID;
                        prodExist.IN_MARCA_ID = pro.IN_MARCA_ID;
                        prodExist.IN_MEDIDA_ID = pro.IN_MEDIDA_ID;
                        prodExist.IN_PROVEEDOR_ID = pro.IN_PROVEEDOR_ID;

                        contexto.SaveChanges();
                        return Ok();

                    }
                    catch (Exception ex)
                    {
                        return BadRequest();
                    }

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest();
            }

        }
    }
}
