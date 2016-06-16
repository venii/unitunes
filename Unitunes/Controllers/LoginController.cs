using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;

namespace Unitunes.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        // POST: VerifyLogin
        [HttpPost]
        public ActionResult VerifyLogin()
        {
            //Unitunes.Models.Academico;   
            //ModelState
            //Unitunes.Models.dbEntities.

            //var login = from Academico where academico.Email = Request['login'];
            //IEnumerable<Academico> resultado1 = from e in fonteDados
            //                                 where e.Cor == "vermelha"
            //                                 select e.Nome;

            var ctx = new dbEntities();
            
            var login = ctx.AcademicoSet;
            String requestU = Request["login"];
            String requestP = Request["password"];
            
            //foreach de dados vindo do loginDb(dbcontext)
            //linq
            var existeUsuario = from u in login where u.Email == requestU & u.Password == requestP  select u;

            if (existeUsuario.Count() == 0)
            {

                
                    Academico a = new Academico();
                    a.Password = requestP;
                    a.Email = requestU;
                    a.PrimeiroNome = "juca";
                    a.SegundoNome = "silva";

                    ctx.AcademicoSet.Add(a);
                    ctx.SaveChanges();


                    ViewBag.login = "nao existe";
                    ViewBag.password = "nao existe";
                
            }
            else
            {
                ViewBag.login = "existe";
                ViewBag.password = "existe";
            }
            //lambda


            return View();

        }
        
        [HttpPost]
        public ActionResult Registrar(Academico academico)
        {
            if (HttpContext.Request.HttpMethod == "POST")
            {
                //verifica se existe o registro
                //quando enviar o post
                var ctx = new dbEntities();
            

                var academicos = ctx.AcademicoSet;
                var existeUsuario = from u in academicos where u.Email == academico.Email & u.Password == academico.Password select u;

                if (existeUsuario.Count() == 0)
                {
                    ctx.AcademicoSet.Add(academico);
                    ctx.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Erro:", "Usuario Já existe");
                }

                // The action is a POST.
            }
            return View();
        }
        
    }
}