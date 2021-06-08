using entidad.inventario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace vista.inventario.Controllers
{
    public class HomeController : Controller
    {
        ModelSinInventario contexto = new ModelSinInventario();
        string urlapi = "http://localhost:7484/";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> verproducto()
        {
            List<IN_PRODUCTO> listProducto = new List<IN_PRODUCTO>();
            using (var htclient = new HttpClient())
            {
                
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = await htclient.GetAsync("api/producto/");
                if (resp.IsSuccessStatusCode)
                {
                    var response = resp.Content.ReadAsStringAsync().Result;
                    listProducto = JsonConvert.DeserializeObject<List<IN_PRODUCTO>>(response);
                }
                return View(listProducto);
            }

        }

        public async Task<ActionResult> nuevoproducto()
        {

            #region ~~Categoria

            List<IN_CATEGORIA> listCategoria = new List<IN_CATEGORIA>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/categoria/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listCategoria = JsonConvert.DeserializeObject<List<IN_CATEGORIA>>(result);
                }

            }

            List<SelectListItem> listSelectcategoria = new List<SelectListItem>();
            foreach (IN_CATEGORIA item in listCategoria)
            {
                listSelectcategoria.Add(new SelectListItem() { Text = item.IN_DESCRIPCION_CATEGORIA, Value = item.IN_CATEGORIA_ID.ToString() });
            }

            ViewBag.BAcategoria = new SelectList(listSelectcategoria, "Value", "Text");

            #endregion

            #region ~~Medida

            List<IN_MEDIDA> listMedida = new List<IN_MEDIDA>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/medida/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listMedida = JsonConvert.DeserializeObject<List<IN_MEDIDA>>(result);
                }

            }

            List<SelectListItem> listSelectMedida = new List<SelectListItem>();
            foreach (IN_MEDIDA item in listMedida)
            {
                listSelectMedida.Add(new SelectListItem() { Text = item.IN_DETALLE_MEDIDA, Value = item.IN_ID_MEDIDA.ToString() });
            }

            ViewBag.BAmedida = new SelectList(listSelectMedida, "Value", "Text");

            #endregion

            #region ~~Proveedor

            List<IN_PROVEEDOR> listProveedora = new List<IN_PROVEEDOR>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/proveedor/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listProveedora = JsonConvert.DeserializeObject<List<IN_PROVEEDOR>>(result);
                }

            }

            List<SelectListItem> listSelectProveedor = new List<SelectListItem>();
            foreach (IN_PROVEEDOR item in listProveedora)
            {
                listSelectProveedor.Add(new SelectListItem() { Text = item.IN_DETALLE_PROVEEDOR, Value = item.IN_PROVEEDOR_ID.ToString() });
            }

            ViewBag.BAproveedor = new SelectList(listSelectProveedor, "Value", "Text");

            #endregion

            #region ~~Marca

            List<IN_MARCA> listMarca = new List<IN_MARCA>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/marca/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listMarca = JsonConvert.DeserializeObject<List<IN_MARCA>>(result);
                }

            }

            List<SelectListItem> listSelectMarca = new List<SelectListItem>();
            foreach (IN_MARCA item in listMarca)
            {
                listSelectMarca.Add(new SelectListItem() { Text = item.IN_DETALLE_MARCA, Value = item.IN_MARCA_ID.ToString() });
            }

            ViewBag.BAmarca = new SelectList(listSelectMarca, "Value", "Text");

            #endregion

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> nuevoproducto(IN_PRODUCTO producto)
        {
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi + "api/producto/");
                var resp = htclient.PostAsJsonAsync<IN_PRODUCTO>("productos", producto);
                resp.Wait();
                var result = resp.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("verproducto");
                }
            }
            ModelState.AddModelError(string.Empty, "Error, contacto con el jefe de area");
            return View(producto);
        }

        public async Task<ActionResult> editaproducto(int id)
        {
            #region ~~Categoria

            List<IN_CATEGORIA> listCategoria = new List<IN_CATEGORIA>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/categoria/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listCategoria = JsonConvert.DeserializeObject<List<IN_CATEGORIA>>(result);
                }

            }

            List<SelectListItem> listSelectcategoria = new List<SelectListItem>();
            foreach (IN_CATEGORIA item in listCategoria)
            {
                listSelectcategoria.Add(new SelectListItem() { Text = item.IN_DESCRIPCION_CATEGORIA, Value = item.IN_CATEGORIA_ID.ToString() });
            }

            ViewBag.BAcategoria = new SelectList(listSelectcategoria, "Value", "Text");

            #endregion

            #region ~~Medida

            List<IN_MEDIDA> listMedida = new List<IN_MEDIDA>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/medida/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listMedida = JsonConvert.DeserializeObject<List<IN_MEDIDA>>(result);
                }

            }

            List<SelectListItem> listSelectMedida = new List<SelectListItem>();
            foreach (IN_MEDIDA item in listMedida)
            {
                listSelectMedida.Add(new SelectListItem() { Text = item.IN_DETALLE_MEDIDA, Value = item.IN_ID_MEDIDA.ToString() });
            }

            ViewBag.BAmedida = new SelectList(listSelectMedida, "Value", "Text");

            #endregion

            #region ~~Proveedor

            List<IN_PROVEEDOR> listProveedora = new List<IN_PROVEEDOR>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/proveedor/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listProveedora = JsonConvert.DeserializeObject<List<IN_PROVEEDOR>>(result);
                }

            }

            List<SelectListItem> listSelectProveedor = new List<SelectListItem>();
            foreach (IN_PROVEEDOR item in listProveedora)
            {
                listSelectProveedor.Add(new SelectListItem() { Text = item.IN_DETALLE_PROVEEDOR, Value = item.IN_PROVEEDOR_ID.ToString() });
            }

            listSelectProveedor.First().Selected = true;

            ViewBag.BAproveedor = new SelectList(listSelectProveedor, "Value", "Text");

            #endregion


            #region ~~Marca

            List<IN_MARCA> listMarca = new List<IN_MARCA>();
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                htclient.DefaultRequestHeaders.Clear();
                htclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage resp = await htclient.GetAsync("api/marca/");
                if (resp.IsSuccessStatusCode)
                {
                    var result = resp.Content.ReadAsStringAsync().Result;
                    listMarca = JsonConvert.DeserializeObject<List<IN_MARCA>>(result);
                }

            }

            List<SelectListItem> listSelectMarca = new List<SelectListItem>();
            foreach (IN_MARCA item in listMarca)
            {
                listSelectMarca.Add(new SelectListItem() { Text = item.IN_DETALLE_MARCA, Value = item.IN_MARCA_ID.ToString() });
            }

            ViewBag.BAmarca = new SelectList(listSelectMarca, "Value", "Text");

            #endregion

            IN_PRODUCTO prod = null;
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                var resp = htclient.GetAsync($"api/producto/{id}");
                resp.Wait();
                var result = resp.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsAsync<IN_PRODUCTO>();
                    content.Wait();
                    prod = content.Result;
                }
            }
            return View(prod);

        }

        [HttpPost]
        public ActionResult editaproducto(IN_PRODUCTO prod)
        {
            using (var htclient = new HttpClient())
            {
                htclient.BaseAddress = new Uri(urlapi);
                var resp = htclient.PutAsJsonAsync<IN_PRODUCTO>($"api/producto/{prod.IN_PRODUCTO_CODIGO}", prod);
                resp.Wait();
                var result = resp.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("verproducto");
                }
            }
            return View(prod);
        }
    }
}