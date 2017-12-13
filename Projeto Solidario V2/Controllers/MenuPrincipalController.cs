using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class MenuPrincipalController : Controller
    {
        // GET: MenuPrincipal
        public ActionResult Index()
        {
            VinculoAfinidadeDao vinculoafinidadedao = new VinculoAfinidadeDao();   

            if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade) Session["Entidade"];
                if(entidadesessao.Status != 1)
                {
                    return RedirectToAction("Bloqueado");
                }

                if (!vinculoafinidadedao.ExisteAfinidade(entidadesessao))
                {
                    return RedirectToAction("Index","VinculoAfinidade");
                }
            }
            else if (Session["Voluntario"] != null)
            {
                Voluntario voluntariosessao = (Voluntario) Session["Voluntario"];
                if (!vinculoafinidadedao.ExisteAfinidade(voluntariosessao))
                {
                    return RedirectToAction("Index", "VinculoAfinidade");
                }
            }
            return View();
        }


        public ActionResult Bloqueado()
        {
                Entidade entidadesessao = (Entidade)Session["Entidade"];
                ViewBag.Entidade = entidadesessao;
                return View();
        }
    }
}