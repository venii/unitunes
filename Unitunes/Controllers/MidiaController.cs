using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Unitunes.Controllers
{
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
                        //UPLOAD DE MIDIAS PARA O SERVIDOR
                        var fileName = Path.GetFileName(midiaViewModel.arquivoUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/midias"), fileName);
                        midiaViewModel.arquivoUpload.SaveAs(path);
                    }
                }
               /* else
                {
                    string messages = string.Join("; ", ModelState.Values
                                         .SelectMany(x => x.Errors)
                                         .Select(x => x.ErrorMessage));

                    ModelState.AddModelError("error", messages);
                }*/
            }
            return View();
        }
    }
}