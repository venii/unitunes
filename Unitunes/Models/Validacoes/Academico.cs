using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unitunes.Models
{
    [MetadataType(typeof(AcademicoMetaData))]
    public partial class Academico
    {
       
    
    }

    public class AcademicoMetaData
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "PrimeiroNome is required")]
        public string PrimeiroNome { get; set; }
        [Required(ErrorMessage = "SegundoNome is required")]
        public string SegundoNome { get; set; }

    }
}