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
        public ActionResult Login()
        {

            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(string login,string password)
        {

            Academico novoLogin = new Academico();
            novoLogin.Email = login;
            novoLogin.Password = password;

            if (Unitunes.Models.ModelosApp.Academico.isAcademicoExists(novoLogin))
            {
                Unitunes.Models.ModelosApp.Academico.autenticar(novoLogin);
                return Redirect("/Login/Principal");

            }
            else
            {
                ModelState.AddModelError("error", "Usuario não existe");
            }

            return View();

        }

        //GET : REGISTAR
        public ActionResult Registrar()
        {
       
            return View();
        }

        //POST : REGISTRAR
        [HttpPost]
        public ActionResult Registrar(Academico academico)
        {
            
            //verifica se existe o registro
            //quando enviar o post

            if (ModelState.IsValid)
            {

                var ctx = new dbEntities();

                var academicos = ctx.AcademicoSet;


                //verifica se usuario nao existe
                if (!Unitunes.Models.ModelosApp.Academico.isAcademicoExists(academico))
                {

                    //cria usuario
                    Unitunes.Models.ModelosApp.Academico.adicionarAcademico(academico);
                    Unitunes.Models.ModelosApp.Academico.autenticar(academico);
                    return Redirect("/Login/Principal");

                }
                else
                {
                    ModelState.AddModelError("error", "Usuario Já existe");
                }
            }
            else
            {
                ModelState.AddModelError("error", "Preencha o formulario corretamente");
            }
                // The action is a POST.
            return View();
        }


        //necessita login
        [Authorize]
        public ActionResult Logout()
        {
            Unitunes.Models.ModelosApp.Academico.logoff();
            return Redirect("/Login/Login");
        }

        //necessita loginUnitunes.Models
        [Authorize]
        public ActionResult Principal()
        {
            ViewBag.nome = Unitunes.Models.ModelosApp.Academico.getIdNome();
            //passa o model pelo view

            //listar tipos
            // nome
            //

            IEnumerable<Unitunes.Models.Media> media = new List<Media>();
            return View(media);
        }

        [Authorize]
        [HttpPost]    
        public ActionResult Principal(string tipo,string nome)
        {
            ViewBag.nome = Unitunes.Models.ModelosApp.Academico.getIdNome();
            var ctx = new dbEntities();

            var medias = ctx.MediaSet;
            var academico = ctx.AcademicoSet;
            IQueryable<Media> resultado = null;
            switch (tipo)
            {
                case "Musica":
                      resultado = from m in medias
                                    join a in academico on m.AcademicoId equals a.Id
                                    where m.Nome.Contains("%/" + nome + "/%") && m.Ativo == true && m is Musica
                                    select new {Medias = m, Academico = a };
                    break;
                case "Video":
                     resultado = from m in medias
                                    join a in academico on m.AcademicoId equals a.Id
                                    where m.Nome.Contains("%/" + nome + "/%") && m.Ativo == true && m is Musica
                                    select new { Medias = m, Academico = a };
                    break;
                case "Podcast":
                    break;
                case "Livro":
                    break;
            }
            
            
            IEnumerable<Unitunes.Models.Media> media = new List<Media>();
            return View(media);
        }
 
    }
}