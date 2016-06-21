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
    public class MusicaController : Controller
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
        public ActionResult Criar(Unitunes.Models.ViewModel.MusicaViewModel musicaViewModel)
        {
            if (ModelState.IsValid)
            {
                if (musicaViewModel.arquivoUpload != null)
                {
                    if (musicaViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(musicaViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        musicaViewModel.arquivoUpload.SaveAs(path);

                        musicaViewModel.midia.Caminho = path;
                        //relaciona o id do acadamico na sessao e relaciona na media

                    }

                }

                musicaViewModel.midia.AcademicoId = Unitunes.Models.ModelosApp.Academico.getId();
                musicaViewModel.midia.Ativo = true;

                var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
                midiaRepo.Save(musicaViewModel.midia);

                return Redirect("/Midia/Listar");
            }

            return View(musicaViewModel);
        }

        // GET: Videos/Edit/5
        public ActionResult Editar(int id)
        {
            Unitunes.Models.ViewModel.MusicaViewModel musicaViewModel = new Models.ViewModel.MusicaViewModel();
            
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();

            musicaViewModel.midia = (Musica)midiaRepo.GetById(id);


            return View(musicaViewModel);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Unitunes.Models.ViewModel.MusicaViewModel musicaViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();

            if (ModelState.IsValid)
            {
                if (musicaViewModel.arquivoUpload != null)
                {
                    if (musicaViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(musicaViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        musicaViewModel.arquivoUpload.SaveAs(path);


                        musicaViewModel.midia.Caminho = path;

                    }
                }

                //nao esquecer academicoID
                musicaViewModel.midia.Ativo = true;
                musicaViewModel.midia.AcademicoId = Unitunes.Models.ModelosApp.Academico.getId();
                midiaRepo.Update(musicaViewModel.midia);

                return Redirect("/Midia/Listar");
            }
            return View(musicaViewModel);


 
        }

        // GET: Videos/Delete/5
        public ActionResult Deletar(int id)
        {
            Unitunes.Models.ViewModel.MusicaViewModel musicaViewModel = new Models.ViewModel.MusicaViewModel();

            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();

            musicaViewModel.midia = (Musica)midiaRepo.GetById(id);


            return View(musicaViewModel);

        }

        // POST: Videos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(Unitunes.Models.ViewModel.MusicaViewModel musicaViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
            musicaViewModel.midia.Ativo = false;

            midiaRepo.Update(musicaViewModel.midia);
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
