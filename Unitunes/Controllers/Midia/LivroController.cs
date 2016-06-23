using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;
using Unitunes.Models.Abstratos;

namespace Unitunes.Controllers.Midia
{
    public class LivroController : Controller
    {
        private dbEntities db = new dbEntities();


        // GET: Videos/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Unitunes.Models.ViewModel.LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                if (livroViewModel.arquivoUpload != null)
                {
                    if (livroViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(livroViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        livroViewModel.arquivoUpload.SaveAs(path);

                        livroViewModel.midia.Caminho = path;
                        //relaciona o id do acadamico na sessao e relaciona na media

                    }

                }

                livroViewModel.midia.AcademicoId = Unitunes.Models.Servicos.Academico.getId();
                livroViewModel.midia.Ativo = true;

                var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();
                midiaRepo.Save(livroViewModel.midia);

                return Redirect("/Midia/Listar");
            }

            return View(livroViewModel);
        }

        // GET: Videos/Edit/5
        public ActionResult Editar(int id)
        {
            Unitunes.Models.ViewModel.LivroViewModel livroViewModel = new Models.ViewModel.LivroViewModel();

            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            livroViewModel.midia = (Livro)midiaRepo.GetById(id);


            return View(livroViewModel);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Unitunes.Models.ViewModel.LivroViewModel livroViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            if (ModelState.IsValid)
            {
                if (livroViewModel.arquivoUpload != null)
                {
                    if (livroViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(livroViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        livroViewModel.arquivoUpload.SaveAs(path);


                        livroViewModel.midia.Caminho = path;

                    }
                }

                //nao esquecer academicoID
                livroViewModel.midia.Ativo = true;
                livroViewModel.midia.AcademicoId = Unitunes.Models.Servicos.Academico.getId();
                midiaRepo.Update(livroViewModel.midia);

                return Redirect("/Midia/Listar");
            }
            return View(livroViewModel);


 
        }
        // GET: Videos/Delete/5
        public ActionResult Visualizar(int id)
        {
            Unitunes.Models.ViewModel.LivroViewModel livroViewModel = new Models.ViewModel.LivroViewModel();

            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            livroViewModel.midia = (Livro)midiaRepo.GetById(id);


            return View(livroViewModel);

        }

        // GET: Videos/Delete/5
        public ActionResult Deletar(int id)
        {
            Unitunes.Models.ViewModel.LivroViewModel livroViewModel = new Models.ViewModel.LivroViewModel();

            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();

            livroViewModel.midia = (Livro)midiaRepo.GetById(id);


            return View(livroViewModel);

        }

        // POST: Videos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(Unitunes.Models.ViewModel.LivroViewModel livroViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();
            livroViewModel.midia.Ativo = false;

            midiaRepo.Update(livroViewModel.midia);
            return Redirect("/Midia/Listar");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
