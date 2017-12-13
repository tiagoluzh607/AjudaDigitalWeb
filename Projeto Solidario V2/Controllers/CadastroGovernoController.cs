using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class CadastroGovernoController : Controller
    {
        // GET: CadastroGoverno
        public ActionResult Index()
        {
            CidadeDao cidade = new CidadeDao();
            ViewBag.Cidade = cidade.Listar();
            Governo governo = (Governo)Session["Governo"];
            ViewBag.Governo = governo;

            return View();
        }
    }
}