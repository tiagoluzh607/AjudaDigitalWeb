using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class LancarCampanhaController : Controller
    {
        // GET: LancarCampanha
        public ActionResult Index()
        {
            CampanhaDao campanhadao = new CampanhaDao();

            if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade)Session["Entidade"];
                ViewBag.Campanhas = campanhadao.BuscaporEntidade(entidadesessao);
            }

            return View();
        }

        
        public ActionResult Create(Campanha campanha)
        {         
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Campanha campanha)
        {
            //Recupera a Entidade da sessão para adicionar a campanha
            Entidade entidadesessao = (Entidade)Session["Entidade"];
            campanha.Entidadeid = entidadesessao.id;

            CampanhaDao campanhadao = new CampanhaDao();

            if (campanha.id > 0)
            {
                //Atualiza Campanha no Banco
                campanhadao.Atualizar(campanha);
            }
            else
            {
                //Salva Campanha no banco
                campanhadao.Adicionar(campanha);
            }
            
            //Salva Campanha na sessão
            Session["Campanha"] = campanha;

            return RedirectToAction("Index", "VinculoAfinidade");
        }

        public ActionResult Edit(int id)
        {
            CampanhaDao campanhadao = new CampanhaDao();
            ViewBag.Campanha = campanhadao.BuscarPorId(id);

            return View();
        }

        public ActionResult VisualizaParticipante()
        {
            return View();
        }
    }
}