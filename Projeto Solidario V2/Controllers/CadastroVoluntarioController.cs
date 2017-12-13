using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class CadastroVoluntarioController : Controller
    {
        // GET: CadastroVoluntario
        public ActionResult Index()
        {
            //Passa as Cidades
            CidadeDao cidade = new CidadeDao();
            ViewBag.Cidade = cidade.Listar();

            //Passa o Voluntario
            Voluntario voluntario = new Voluntario();

            if (Session["Voluntario"] != null)
            {
                voluntario = (Voluntario)Session["Voluntario"];
            }

            else
            {
                Login login = new Login();

                voluntario.Limpar();               
                login.Limpar();
                voluntario.Login = login;
            }

            ViewBag.Voluntario = voluntario;
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Voluntario voluntario, Login login)
        {
            VoluntarioDao voluntariodao = new VoluntarioDao();
            voluntario.Login = login;
            //Se O voluntario já existir atualiza os Dados
            if (voluntario.id > 0)
            {
                LoginDao logindao = new LoginDao();
                logindao.Atualizar(login);

                voluntario.Loginid = login.id;
                voluntariodao.Atualizar(voluntario);

                //Atualiza a sessao e redireciona para o menu principal
                voluntario.Login = logindao.BuscarPorId(voluntario.Loginid);
                Session["Voluntario"] = voluntario;
                return RedirectToAction("Index", "VinculoAfinidade");
            }

            //Caso contrario cria novo registro
            else
            {          
                voluntariodao.Adicionar(voluntario);
            }            
            
            return RedirectToAction("Index","MenuPrincipal");
        }
    }
}