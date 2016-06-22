﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;
using Unitunes.Models.ViewModel;

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

            var resultado = (IEnumerable<PrincipalViewModel>)null;
            return View(resultado);
        }

        [Authorize]
        [HttpPost]    
        public ActionResult Principal(string tipo,string nome)
        {
            ViewBag.nome = Unitunes.Models.ModelosApp.Academico.getIdNome();
            var ctx = new dbEntities();

            var medias = ctx.MediaSet;
            var academico = ctx.AcademicoSet;
            var resultado = (IEnumerable<PrincipalViewModel>)null;

            switch (tipo)
            {
                case "Musica":
                    resultado =     (from m in medias
                                    join a in academico on m.AcademicoId equals a.Id
                                    where m.Nome.Contains("%/" + nome + "/%") && m.Ativo == true && m is Musica
                                     select new PrincipalViewModel { midia = m, academico = (Academico)a }).AsEnumerable();

                    break;
                case "Video":
                    resultado = (from m in medias
                                    join a in academico on m.AcademicoId equals a.Id
                                    where m.Nome.Contains("%/" + nome + "/%") && m.Ativo == true && m is Video
                                 select new PrincipalViewModel { midia = m, academico = (Academico)a }).AsEnumerable();
                    break;
                case "Podcast":
                    resultado = (from m in medias
                                join a in academico on m.AcademicoId equals a.Id
                                where m.Nome.Contains("%/" + nome + "/%") && m.Ativo == true && m is Podcast
                                 select new PrincipalViewModel { midia = m, academico = (Academico)a }).AsEnumerable();
                    break;
                case "Livro":
                    resultado = (from m in medias
                                join a in academico on m.AcademicoId equals a.Id
                                where m.Nome.Contains("%/" + nome + "/%") && m.Ativo == true && m is Livro
                                select new PrincipalViewModel { midia = m, academico = (Academico)a }).AsEnumerable();
                    break;
            }

            return View(resultado);

            
        }
 
    }
}