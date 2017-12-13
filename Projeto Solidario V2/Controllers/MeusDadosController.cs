using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class MeusDadosController : Controller
    {
        // GET: MeusDados
        public ActionResult Index()
        {

            if(Session["Voluntario"] != null){
                return RedirectToAction("Index", "CadastroVoluntario");
            }
            else if(Session["Entidade"] != null){
                return RedirectToAction("Index", "CadastroEntidade");
            }
            else if(Session["Governo"] != null){
                return RedirectToAction("Index", "CadastroGoverno");
            }

            //Caso nenhuma das opções aconteça
            return RedirectToAction("Index", "MenuPrincipal");
            
        }
    }
}