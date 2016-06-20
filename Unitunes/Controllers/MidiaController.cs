using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;
using Unitunes.Models.Abstratos;
using Unitunes.Models.ModelosApp;
using Unitunes.Models.ViewModel;

namespace Unitunes.Controllers
{
    [Authorize]
    public class MidiaController : Controller
    {
        //GET: CRIAR Midia
        public ActionResult Criar()
        {
           return View();
        }

        //POST: CRIAR Midia
        [HttpPost]
        public ActionResult Criar(Unitunes.Models.ViewModel.MidiaViewModel midiaViewModel)
        {
           if (ModelState.IsValid){
               if (midiaViewModel.arquivoUpload != null)
               {
                   if (midiaViewModel.arquivoUpload.ContentLength > 0)
                   {

                       var fileName = Path.GetFileName(midiaViewModel.arquivoUpload.FileName);
                       var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                       //salva no servidor
                       midiaViewModel.arquivoUpload.SaveAs(path);
                       
                       midiaViewModel.midia.Caminho = path;
                       //relaciona o id do acadamico na sessao e relaciona na media

                   }

               }

               midiaViewModel.midia.AcademicoId = Unitunes.Models.ModelosApp.Academico.getId();
               midiaViewModel.midia.Ativo = true;
               
               var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
               midiaRepo.Save(midiaViewModel.midia);

               return Redirect("/Login/Principal");
             
           }
                
           return View();
        }

        // GET: EDITAR MIDIA
        public ActionResult Editar(int id)
        {
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
                
            MidiaViewModel mv = new MidiaViewModel();

            mv.midia = midiaRepo.GetById(id);

            return View(mv);
        }
        
        // POST: EDITAR MIDIA
        [HttpPost]
        public ActionResult Editar(Unitunes.Models.ViewModel.MidiaViewModel midiaViewModel)
        {
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();

            if (ModelState.IsValid)
            {
                if (midiaViewModel.arquivoUpload != null)
                {
                    if (midiaViewModel.arquivoUpload.ContentLength > 0)
                    {

                        var fileName = Path.GetFileName(midiaViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        //salva no servidor
                        midiaViewModel.arquivoUpload.SaveAs(path);


                        midiaViewModel.midia.Caminho = path;

                    }
                }
                midiaRepo.Update(midiaViewModel.midia);

                return Redirect("/Midia/Listar");
            }
            return View(midiaViewModel);
        }

        //GET : LISTAR MIDIAS
        public ActionResult Listar()
        {
            var midiaRepo = Singleton<Unitunes.Models.ModelosApp.Midia>.Instance();
            //passa o model pelo view
            int id = Unitunes.Models.ModelosApp.Academico.getId();

            var minhasMidias = midiaRepo.GetByIdAcademico(id);


            return View(minhasMidias);
        }

        //GET : LISTAR MIDIAS
        public ActionResult CriarNovaMidia()
        {

            
            return View();
        }

        //GET : LISTAR MIDIAS
        [HttpPost]
        public ActionResult CriarNovaMidia(int opt)
        {
            if (opt == 0)
            {
                
                return Redirect("/Video/Criar");
            }

            if (opt == 1)
            {

                return Redirect("/Livro/Criar");
            }

            if (opt == 2)
            {

                return Redirect("/Musica/Criar");
            }

            if (opt == 3)
            {

                return Redirect("/Podcast/Criar");
            }

            return View();
        }
   }
        
        
 }