//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unitunes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transacao
    {
        public Transacao()
        {
            this.MediasTransacao = new HashSet<Media>();
        }
    
        public int Id { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Academico AcademicoDaTransacao { get; set; }
        public virtual ICollection<Media> MediasTransacao { get; set; }
    }
}
