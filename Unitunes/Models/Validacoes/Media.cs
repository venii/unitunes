using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Unitunes.Models
{
    [MetadataType(typeof(MediaMetaData))]
    public partial class Media
    {
        /*adiciona validacao de MediaMetada em Media partial*/
    }

    public class MediaMetaData
    {
        [Required(ErrorMessage = "Nome is required")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome is required")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preco is required")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Categoria is required")]
        public string Categoria { get; set; }

    }
}