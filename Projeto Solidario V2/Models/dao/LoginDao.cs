using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Solidario_V2.Models.dao
{
    public class LoginDao
    {
        public void Adicionar(Login login)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.login.Add(login); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public void Excluir(Login login)
        {
            using (var context = new AjudaDigitalContext())
            {
                context.login.Remove(login); //adicionando o objeto afinidade da classeAjudaDigitalContext
                context.SaveChanges();
            }
        }

        public IList<Login> Listar()
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.login.ToList();
            }
        }

        public Login BuscarPorId(int id)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                return contexto.login.Find(id);
            }
        }

        public Login BuscarPorEmaileSenha(string email, string senha)
        {
            using (var contexto = new AjudaDigitalContext())
            {

                var busca = from l in contexto.login
                            where l.Email == email && l.Senha == senha
                            select l;


                Login login = busca.ToList()[0];
                return login;
            }

        }

        public void Atualizar(Login login)
        {
            using (var contexto = new AjudaDigitalContext())
            {
                contexto.Entry(login).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public bool ExisteLogin(Login login)
        {
            using (var contexto = new AjudaDigitalContext())
            {                               //contexto.login vem do AjudaDigitalContextDao
                var lista = (from l in contexto.login
                             where l.Email == login.Email && l.Senha == login.Senha  //l.Senha vem do banco de dados == login.Senha é a informação que o usuario digitou
                             select l
                            );
                IList<Login> logins = lista.ToList();


                foreach(var l in logins)
                {
                    if (l.Email != null)
                    {
                        return true;
                    }
                }

            }

            return false;

        }


    }
}