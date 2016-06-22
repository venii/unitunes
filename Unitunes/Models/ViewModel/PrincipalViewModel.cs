using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unitunes.Models.ViewModel
{
    public class PrincipalViewModel : MidiaViewModel
    {
        public Media midia { get; set; }
        public Academico academico { get; set; }
    }
}