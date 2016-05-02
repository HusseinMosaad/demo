using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : Controller
    {
        // GET: Product

        [Route("list")]
        public ActionResult List()
        {
            return View();
        }
    }
}