using Projeto_Solidario_V2.Models;
using Projeto_Solidario_V2.Models.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Solidario_V2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult VerificaUsuario()
        {
            Session["Voluntario"] = null;
            Session["Entidade"] = null;
            Session["Governo"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult ValidaLogin(Login login)
        {
            LoginDao logindao = new LoginDao();
            
            if (logindao.ExisteLogin(login))
            {

                Login l = logindao.BuscarPorEmaileSenha(login.Email, login.Senha);


                VoluntarioDao voluntariodao = new VoluntarioDao();
                Voluntario voluntario = voluntariodao.BuscaVoluntarioporLogin(l);
                
                EntidadeDao entidadedao = new EntidadeDao();
                Entidade entidade = entidadedao.BuscaEntidadeporLogin(l);
                
                GovernoDao governodao = new GovernoDao();
                Governo governo = governodao.BuscaGovernoporLogin(l);
                

                if (entidade != null)
                {
                    entidade.Login = l;
                    Session["Entidade"] = entidade;
                }
                else if (voluntario != null)
                {
                    voluntario.Login = l;
                    Session["Voluntario"] = voluntario;
                }
                else
                {
                    governo.Login = l;
                    Session["Governo"] = governo;
                }
               
                return RedirectToAction("Index", "MenuPrincipal");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        
    }
}