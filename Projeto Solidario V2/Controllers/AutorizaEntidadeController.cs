using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class AutorizaEntidadeController : Controller
    {
        // GET: AutorizaEntidade
        public ActionResult Index()
        {
            EntidadeDao entidadedao = new EntidadeDao();
            ViewBag.EntidadesAguardandoLiberacao = entidadedao.ListaAguardandoLiberacao();
            ViewBag.EntidadesNaoAguardandoLiberacao = entidadedao.ListaNaoAguardandoLiberacao();
                       

            return View();
        }

        public ActionResult Edit(int id)
        {
            EntidadeDao entidadedao = new EntidadeDao();
            ViewBag.Entidade = entidadedao.BuscarPorId(id);
            return View();
        }

        public ActionResult EditSalvar(int id, Entidade entidade)
        {
            EntidadeDao entidadedao = new EntidadeDao();
            Entidade objetoentidade = entidadedao.BuscarPorId(id);
            objetoentidade.Status = entidade.Status;

            entidadedao.Atualizar(objetoentidade);

            return RedirectToAction("Index");
        }

    }
}