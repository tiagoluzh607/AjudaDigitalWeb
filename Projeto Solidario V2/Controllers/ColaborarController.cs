using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class ColaborarController : Controller
    {
        // GET: Colaborar
        public ActionResult Edit()
        {
            return RedirectToAction("Colaborar","ParticiparCampanha");
        }

        public ActionResult Delete()
        {
            return RedirectToAction("Colaborar", "ParticiparCampanha");
        }
    }
}