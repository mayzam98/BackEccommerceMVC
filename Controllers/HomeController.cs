using BackEccommerceMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BackEccommerceMVC.Controllers
{
    public class HomeController : Controller
    {

        public async  Task<ActionResult>  Inicio(string nombreBuscar)
        {
            //https://qastudiof.myvtex.com/api/catalog_system/pub/products/search
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://qastudiof.myvtex.com/api/catalog_system/pub/products/search");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            List<Product> listaFiltrada = new List<Product>();
            if (nombreBuscar != null)
            {
                foreach (var item in products)
                {
                    if (item.productName.Contains(nombreBuscar))
                    {

                        listaFiltrada.Add(item);
                    }
                }
            }

            return View(listaFiltrada);
        }
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
    }
}