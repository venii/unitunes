using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;
using Unitunes.Models.Abstratos;
using Unitunes.Models.ModelosApp;

namespace Unitunes.Controllers
{
    [Authorize]
    public class MidiaController : Controller
    {
        // GET: Midia
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Criar(Unitunes.Models.ViewModel.MidiaViewModel midiaViewModel)
        {
            if (HttpContext.Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    if (midiaViewModel.arquivoUpload.ContentLength > 0)
                    {

                            var fileName = Path.GetFileName(midiaViewModel.arquivoUpload.FileName);
                            var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                            midiaViewModel.arquivoUpload.SaveAs(path);
                            
                            midiaViewModel.midia.Caminho = path;
                            //relaciona o id do acadamico na sessao e relaciona na media
                            midiaViewModel.midia.AcademicoId = Unitunes.Models.ModelosApp.Academico.getId();

                            var midiaRepo = Singleton<Midia>.Instance();
                            int idSave = midiaRepo.SaveModel(midiaViewModel.midia);
                            
                            return Redirect("/Login/Principal");
                        }
                    }
                }
   
                return View();
            }


            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult Listar()
            {
                var midiaRepo = Singleton<Midia>.Instance();
                //passa o model pelo view
                int id = Unitunes.Models.ModelosApp.Academico.getId();

                var minhasMidias = midiaRepo.GetByIdAcademico(id);


                return View(minhasMidias);
            }
        }
        
        
 }