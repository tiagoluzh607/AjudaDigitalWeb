using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class SairController : Controller
    {
        // GET: Sair
        public ActionResult Index()
        {
            Session["Voluntario"] = null;
            Session["Entidade"] = null;
            Session["Governo"] = null;
           return RedirectToAction("Index","Login");
        }
    }
}