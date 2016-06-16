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

            var ctx = new dbEntities();
            
            var login = ctx.AcademicoSet;
            String requestU = Request["login"];
            String requestP = Request["password"];

            Academico novoLogin = new Academico();
            novoLogin.Email = requestU;
            novoLogin.Password = requestP;

            if (Unitunes.Models.ModelosApp.Academico.isAcademicoExists(novoLogin))
            {
                return Redirect("/Login/Principal");

            }
            else
            {
                ModelState.AddModelError("error", "Usuario não existe");
            }

            return View();

        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Registrar(Academico academico)
        {
            if (HttpContext.Request.HttpMethod == "POST")
            {
                //verifica se existe o registro
                //quando enviar o post

                if (academico.Email != null && academico.Password != null)
                {

                    var ctx = new dbEntities();
                    var academicos = ctx.AcademicoSet;
                    
                    
                    //verifica se usuario nao existe
                    if (!Unitunes.Models.ModelosApp.Academico.isAcademicoExists(academico))
                    {
                        
                            //cria usuario
                            Unitunes.Models.ModelosApp.Academico.adicionarAcademico(academico);
                            return Redirect("/Login/Principal");

                    }
                    else
                    {
                        ModelState.AddModelError("error", "Usuario Já existe");
                    }
                }
                else { 
                    ModelState.AddModelError("error", "Preencha o formulario corretamente");
                }
                // The action is a POST.
            }
            return View();
        }
        
    }
}