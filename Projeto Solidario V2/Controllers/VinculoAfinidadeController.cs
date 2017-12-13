using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class VinculoAfinidadeController : Controller
    {
        // GET: VinculoAfinidade
        public ActionResult Index()
        {
            VinculoAfinidadeDao vinculoafinidadedao = new VinculoAfinidadeDao();
            AfinidadeDao afinidadedao = new AfinidadeDao();
            ViewBag.Afinidades = afinidadedao.Listar();

            if (Session["Campanha"] != null)
            {
                Campanha campanhasessao = (Campanha)Session["Campanha"];
                ViewBag.VinculoAfinidades = vinculoafinidadedao.BuscaporCampanha(campanhasessao);

            }
            else if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade)Session["Entidade"];
                ViewBag.VinculoAfinidades = vinculoafinidadedao.BuscaporEntidade(entidadesessao);
            }
            else if (Session["Voluntario"] != null)
            {
                Voluntario voluntariosessao = (Voluntario)Session["Voluntario"];
                ViewBag.VinculoAfinidades = vinculoafinidadedao.BuscaporVoluntario(voluntariosessao);

            }

            return View();
        }
        public ActionResult Salvar()
        {
            if (Session["Campanha"] != null)
            {
               return RedirectToAction("Index","LancarCampanha");
            }
            else if (Session["Entidade"] != null)
            {
                return RedirectToAction("Index", "MenuPrincipal");
            }
            else if (Session["Voluntario"] != null)
            {
                return RedirectToAction("Index", "MenuPrincipal");
            }

            return View();
        }

        public ActionResult Inserir(Afinidade afinidade)
        {
            VinculoAfinidadeDao vinculoafinidadedao = new VinculoAfinidadeDao();
            VinculoAfinidade vinculoafinidade = new VinculoAfinidade();

            vinculoafinidade.Afinidadeid = afinidade.id;

            if (Session["Campanha"] != null)
            {
                Campanha campanhasessao = (Campanha) Session["Campanha"];
                vinculoafinidade.Campanhaid = campanhasessao.id;

            }
            else if (Session["Entidade"] != null)
            {
                Entidade entidadesessao = (Entidade) Session["Entidade"];
                vinculoafinidade.Entidadeid = entidadesessao.id;
            }
            else if (Session["Voluntario"] != null)
            {
                Voluntario voluntariosessao = (Voluntario) Session["Voluntario"];
                vinculoafinidade.Voluntarioid = voluntariosessao.id;
            }

            vinculoafinidadedao.Adicionar(vinculoafinidade);

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            VinculoAfinidadeDao vinculoafinidadedao = new VinculoAfinidadeDao();

            VinculoAfinidade vinculoAexcluir = vinculoafinidadedao.BuscarPorId(id);
           
            vinculoafinidadedao.Excluir(vinculoAexcluir);

            return RedirectToAction("Index");
        }
    }
}