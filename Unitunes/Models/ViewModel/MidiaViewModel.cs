using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unitunes.Models.ViewModel
{
    public class MidiaViewModel
    {
        [Required]
        public Media midia { get; set; }
        public HttpPostedFileBase    arquivoUpload { get; set; }

    }
}