using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitunes.Models;
using Unitunes.Models.Abstratos;
using Unitunes.Models.Servicos;
using Unitunes.Models.ViewModel;

namespace Unitunes.Controllers
{
    [Authorize]
    public class MidiaController : Controller
    {
        

        //GET : LISTAR MIDIAS
        public ActionResult Listar()
        {
            var midiaRepo = Singleton<Unitunes.Models.Repositorios.Midia>.Instance();
            //passa o model pelo view
            int id = Unitunes.Models.Servicos.Academico.getId();

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