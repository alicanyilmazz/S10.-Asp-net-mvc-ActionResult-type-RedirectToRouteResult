using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedirectToRouteResult_sample.Controllers
{
    public class HomeController : Controller
    {
        static List<string> keeper_list = new List<string>(); //server yeniden baslatılana kadar veriler tutulur cunku static tanımlanmıslar.
        // GET: Home
        [HttpGet]
        public ActionResult homepage(string code,string ban,string soyadim) 
        {
            ViewBag.take_list = keeper_list;

            return View();
        }

        [HttpPost]
        public ActionResult homepage(string name,string surname)
        {
            keeper_list.Add(name + " " + surname);

            return new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(   //Burada bulunan verilerin hepsi url tarafında gidecek istersek "name" ve "surname" bilgisini bile url aracılıgıyla gönderebilirdi k.
                    new
                    {
                        action="homepage",
                        controller="Home",
                        code=Guid.NewGuid().ToString(), //mesela code adında bir veri uydurduk Guid tipinden yani sadece uydurduk ve url üzerinden göndereceğiz. 
                        ban="alican",
                        soyadim="yilmaz"
                    }));//tabi suna dikkat edelim sayfa yüklenince adres barında url 'de Home/homepage?kod?=AKSP-ADMA-42EA gibi gelecek fakat Home ve homepage yani
                        // Controller ve Action isimleri özel isimler oldugundan sonradan eklediğimiz code= gibi action= veya controller= gibi gelmez.
                        //Bunun ile ilgili ayarı App_Start in içerisindeki RouteConfig.cs içerisinde bulabilirsiniz.
        }

    }
} 